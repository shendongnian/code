            form.ResizeEnd += (sender, args) =>
            {
                device.ImmediateContext.ClearState();
                
                d2dRenderTarget.Dispose();
                backBuffer.Dispose();
                renderView.Dispose();
                surface.Dispose();
                swapChain.ResizeBuffers(1, 0, 0 , Format.Unknown, SwapChainFlags.AllowModeSwitch);
                backBuffer = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
                renderView = new RenderTargetView(device, backBuffer);
                surface = backBuffer.QueryInterface<Surface>();
                d2dRenderTarget = new RenderTarget(d2dFactory, surface,
                                                            new RenderTargetProperties(new PixelFormat(Format.Unknown, AlphaMode.Premultiplied)));
                
            };
