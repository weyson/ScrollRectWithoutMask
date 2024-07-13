using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MaskByRectTransform : MonoBehaviour
{
    private static readonly int MaskRect = Shader.PropertyToID("_MaskRect");
    public Camera UICamera;
    public Canvas RootCanvas;
    public RectTransform MaskRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        var bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(RootCanvas.transform as RectTransform,
            MaskRectTransform);

        Debug.Log("screen bounds: " + bounds);
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(RootCanvas.transform as RectTransform,
            MaskRectTransform);
        var graphic = GetComponent<Graphic>();
        var rect = new float4(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y,
            bounds.extents.x, bounds.extents.y);
        graphic.material.SetVector(MaskRect, rect);
    }
}