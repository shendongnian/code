    public class CustomGlobal : HttpApplication
    {
        private readonly VendorGlobal _global;
        public CustomGlobal()
        {
            _global = new VendorGlobal();
        }
        protected void Application_Start(Object sender, EventArgs e)
        {
            _global.Application_Start(sender, e);
            // your custom code
        }
    }
