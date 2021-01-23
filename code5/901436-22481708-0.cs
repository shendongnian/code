    struct BlobSettings
    {
        public Vector4 OuterColor;
        public Vector4 InnerColor;
        public float InnerRadius;
        public float OuterRadius;
        public static readonly int Size = 
            BlittableValueType<BlobSettings>.Stride;
    }
    // ...
    
    // Store data within the buffer at the appropriate offsets
    var blockBuffer = new BlobSettings
    {
        OuterColor = new Vector4(0.0f, 0.0f, 0.0f, 0.0f),
        InnerColor = new Vector4(1.0f, 1.0f, 0.75f, 1.0f),
        InnerRadius = 0.25f,
        OuterRadius = 0.45f
    };
    
    // ...
    
    GL.BufferData(BufferTarget.UniformBuffer, 
        (IntPtr)BlockSettings.Size, // faster way to compute struct size
        ref blockBuffer,
        BufferUsageHint.DynamicDraw);
