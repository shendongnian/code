    public class CustomScriptBundle : ScriptBundle
    {
        public CustomScriptBundle(string virtualPath) : base(virtualPath)
        {
            Builder = new CustomScriptBundleBuilder();
        }
        public CustomScriptBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        {
            Builder = new CustomScriptBundleBuilder();
        }
    }
