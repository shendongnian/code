    Shader "Depth Mask" {
        SubShader {
            Tags {"Queue" = "Geometry-10"}
            Lighting Off
            ZTest LEqual
            ZWrite On
            ColorMask 0
            Pass {}
        }
    }
