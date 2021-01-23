    public static Direct3D11.Buffer CreateBuffer<T>(this Direct3D11.Device device, T[] range)
            where T : struct
        {
            int sizeInBytes = Marshal.SizeOf(typeof(T));
            using (var stream = new DataStream(range.Length * sizeInBytes, true, true))
            {
                stream.WriteRange(range);
                stream.Position = 0; // fix
                return new Direct3D11.Buffer(device, stream, new Direct3D11.BufferDescription
                {
                    BindFlags = Direct3D11.BindFlags.VertexBuffer,
                    SizeInBytes = (int)stream.Length,
                    CpuAccessFlags = Direct3D11.CpuAccessFlags.None,
                    OptionFlags = Direct3D11.ResourceOptionFlags.None,
                    StructureByteStride = 0,
                    Usage = Direct3D11.ResourceUsage.Default,
                });
            }
        }
