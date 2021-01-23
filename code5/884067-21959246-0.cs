    public class GlobalSettings : IGlobalSettings
    {
        public static GlobalSettings Instance
        {
            get { return _Instance ?? (_Instance = new GlobalSettings()); }
        } static GlobalSettings _Instance;
    
        public GlobalSettings() 
        {
        }
    
        // More methods/properties here
    }
