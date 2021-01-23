        public void Resize()
        {
            this.Resize(0, 0);
        }
        public void Resize(int w, int h)
        {
            if (this.RenderView != null) { this.RenderView.Dispose(); }
            this.resource.Dispose();
            this.swapchain.ResizeBuffers(1,w, h, SharpDX.DXGI.Format.Unknown, SwapChainFlags.AllowModeSwitch);
            this.resource = Texture2D.FromSwapChain<Texture2D>(this.swapchain, 0);
            this.resource.Dispose();
            this.TextureDesc = this.resource.Description;
            this.RenderView = new RenderTargetView(device.Device, this.resource);
        }
