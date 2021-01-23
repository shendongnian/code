    private static Dictionary<string, string> configSPSynker;
    private static readonly object lockObject = new object();
    internal static Dictionary<string, string> ConfigSPSynker
    {
        get
        {
            lock (lockObject)
            {
                // check inside the lock, because a race condition can occur.
                if (configSPSynker == null)
                {
                    var dictionary = new Dictionary<string,string>();
                    foreach (var key in ConfigurationManager.AppSettings.AllKeys)
                    {
                        if (key.Length > 9 && key.Substring(0, 9) == "SPSynker_")
                            dictionary.Add(key.Substring(9),
                                           ConfigurationManager.AppSettings[key]);
                    }
                    configSPSynker = dictionary;
                }
            }
            return configSPSynker;
        }
    }
