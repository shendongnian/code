    public partial class NotificationStarter : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            WebserviceController webserviceController = new WebserviceController();
            webserviceController.FillWebservicesList();
            webserviceController.CheckWebserviceTimer();
        }
    }
    public class WebserviceController : ConfigurationSection
    {
        private List<WebserviceConfig> _webservicesList; 
        [ConfigurationProperty("Webservices", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(WebservicesCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public WebservicesCollection Webservices
        {
            get { return (WebservicesCollection)base["Webservices"]; }
        }
        public void FillWebservicesList()
        {
            WebserviceController contoller = ConfigurationManager.GetSection("WebservicesSection") as WebserviceController;
            if (contoller != null) 
                _webservicesList = contoller.Webservices.Cast<WebserviceConfig>().ToList();
        }
        public void CheckWebserviceTimer()
        {
            _timer = new Timer(300000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var webservice in _webservicesList)
            {
                try
                {
                    var myRequest = (HttpWebRequest) WebRequest.Create(webservice.Value);
                    var response = (HttpWebResponse) myRequest.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK && webservice.IsOnline)
                    {
                        ...
                    }
                }
            }
        }
    }
    public class WebservicesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WebserviceConfig();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WebserviceConfig) element);
        }
    }
    public class WebserviceConfig : ConfigurationElement
    {
        public WebserviceConfig()
        {
        }
        public WebserviceConfig(string name, string value, bool isOnline)
        {
            Name = name;
            Value = value;
            IsOnline = isOnline;
        }
        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("value", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string Value
        {
            get { return (string) this["value"]; }
            set { this["value"] = value; }
        }
        [ConfigurationProperty("isOnline", IsRequired = true, IsKey = false)]
        public bool IsOnline
        {
            get { return (bool) this["isOnline"]; }
            set { this["isOnline"] = value; }
        }
        public override bool IsReadOnly()
        {
            return false;
        }
    }
