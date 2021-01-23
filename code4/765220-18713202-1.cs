        public DX11SwapChain(DX11Device device, IntPtr handle, Format format, SampleDescription sampledesc)
        {
            this.device = device;
            this.handle = handle;
            SwapChainDescription sd = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), format),
                IsWindowed = true,
                OutputHandle = handle,
                SampleDescription = sampledesc,
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput | Usage.ShaderInput,
                Flags = SwapChainFlags.None
            };
            this.swapchain = new SwapChain(device.Factory, device.Device, sd);
            this.resource = Texture2D.FromSwapChain<Texture2D>(this.swapchain, 0);
            this.TextureDesc = this.resource.Description;
            this.RenderView = new RenderTargetView(device.Device, this.resource);
            this.RenderViewDesc = this.RenderView.Description;
        }
