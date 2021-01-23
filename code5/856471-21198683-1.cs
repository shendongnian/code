    [TestClass]
    public class RenderTests
    {
        private JPGGraphicsDeviceProvider _jpgDevice;
        private RenderPanel _renderPanel;
        public RenderTests()
        {
            _jpgDevice = new JPGGraphicsDeviceProvider(512, 360);
            _renderPanel = new RenderPanel(_jpgDevice.GraphicsDevice);
        }
        [TestMethod]
        public void InstantiatePrism6()
        {
            ColorPrism p = new ColorPrism(6, Color.RoyalBlue, Color.Pink);
            _renderPanel.Add(p);
            _renderPanel.Draw();
            _jpgDevice.SaveCurrentImage("six-Prism.jpg");
        }
    }
