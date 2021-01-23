        public static Texture2D CreateRenderTexture(this RenderHelper helper, int width, int height)
        {
            Texture2DDescription description = new Texture2DDescription
            {
                ArraySize = 1,
                BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
                CpuAccessFlags = CpuAccessFlags.None,
                Format = SlimDX.DXGI.Format.B8G8R8A8_UNorm,
                Width = width,
                Height = height,
                MipLevels = 1,
                OptionFlags = ResourceOptionFlags.None,
                SampleDescription = new SlimDX.DXGI.SampleDescription(1, 0),
                Usage = ResourceUsage.Default,
            };
            return new Texture2D(helper.Device, description);
        }
