    public class DX11SwapChain : IDX11RenderTarget
    {
        private DX11Device device;
        private IntPtr handle;
        private SwapChain swapchain;
        public RenderTargetView RenderView { get; protected set; }
        public RenderTargetViewDescription RenderViewDesc { get; protected set; }
        public Texture2DDescription TextureDesc { get; protected set; }
        private Texture2D resource;
        public IntPtr Handle { get { return this.handle; } }
    }
