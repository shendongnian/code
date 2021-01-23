    public class ClientApp
    {
        public string __invalid_name__@id { get; set; }
        public string appName { get; set; }
        public string assetName { get; set; }
        public string bundle { get; set; }
        public int inventoryAppId { get; set; }
        public string platform { get; set; }
        public string reportedAppName { get; set; }
        public string type { get; set; }
        public double version { get; set; }
    }
    
    public class ClientApps
    {
        public ClientApp clientApp { get; set; }
    }
    
    public class RootObject
    {
        public string deviceUuid { get; set; }
        public ClientApps clientApps { get; set; }
    }
