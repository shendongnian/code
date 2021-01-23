    [StructLayout(LayoutKind.Sequential,Pack=16)]
    public struct cbData
    {
        public Matrix tW;
        public Matrix tColor;
        public Vector4 cAmb;
    }
    BufferDescription bd = new BufferDescription()
    {
       BindFlags = BindFlags.ConstantBuffer,
       CpuAccessFlags = CpuAccessFlags.Write,
       OptionFlags = ResourceOptionFlags.None,
       SizeInBytes = 144, //Matches the struct
       Usage = ResourceUsage.Dynamic
    };
    var cbuffer = new SharpDX.Direct3D11.Buffer(device, bd);
