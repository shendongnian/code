    public class JPGGraphicsDeviceProvider
    {
        private Control _c;
        private RenderTarget2D _renderTarget;
        private int _width;
        private int _height;
        
        public JPGGraphicsDeviceProvider(int width, int height)
        {
            _width = width;
            _height = height;
            _c = new Control();
            PresentationParameters parameters = new PresentationParameters()
            {
                BackBufferWidth = width,
                BackBufferHeight = height,
                BackBufferFormat = SurfaceFormat.Color,
                DepthStencilFormat = DepthFormat.Depth24,
                DeviceWindowHandle = _c.Handle,
                PresentationInterval = PresentInterval.Immediate,
                IsFullScreen = false,
            };
            GraphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter,
                                                GraphicsProfile.Reach,
                                                parameters);
            // Got this idea from here: http://xboxforums.create.msdn.com/forums/t/67895.aspx
            _renderTarget = new RenderTarget2D(GraphicsDevice,
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight);
            GraphicsDevice.SetRenderTarget(_renderTarget);
        }
        /// <summary>
        /// Gets the current graphics device.
        /// </summary>
        public GraphicsDevice GraphicsDevice { get; private set; }
        
        public void SaveCurrentImage(string jpgFilename)
        {
            GraphicsDevice.SetRenderTarget(null);
            int w = GraphicsDevice.PresentationParameters.BackBufferWidth;
            int h = GraphicsDevice.PresentationParameters.BackBufferHeight;
            using (Stream stream = new FileStream(jpgFilename, FileMode.Create))
            {
                _renderTarget.SaveAsJpeg(stream, w, h);
            }
            GraphicsDevice.SetRenderTarget(_renderTarget);
        }
    }
