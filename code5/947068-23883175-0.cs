    static Lazy<Dictionary<string, string>> ConfigSPSSynker = new Lazy<Dictionary<string, string>>( ()=> LoadConfigSettings() );
    static Dictionary<string, string> LoadConfigSettings()
    {
     return  (from k in      System.Configuration.ConfigurationManager.AppSettings.AllKeys
                               where k.Length > 9 && k.Substring(0, 9) == "SPSynker_"
                               select k).ToDictionary(k => k.Substring(9), k => System.Configuration.ConfigurationManager.AppSettings[k]);
    }
    
