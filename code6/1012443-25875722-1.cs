    public class CustomGlobal : HttpApplication
    {
        private readonly VendorGlobal _global;
        private readonly MethodInfo _appStartInfo;
        public CustomGlobal()
        {
            _global = new VendorGlobal();
            _appStartInfo = typeof(VendorGlobal).GetMethod("Application_Start", BindingFlags.Instance | BindingFlags.NonPublic);
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            _appStartInfo.Invoke(_global, new[] {sender, e});
            // your custom code
        }
