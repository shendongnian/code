    public sealed class BrowserIE
    {
        static readonly IE _Instance;
        static BrowserIE()
        {
            Settings.Instance.MakeNewIeInstanceVisible = false;
            _Instance = new IE();
        }
        BrowserIE()
        {
        }
        public static IE Instance
        {
            get { return _Instance; }
        }
    }
