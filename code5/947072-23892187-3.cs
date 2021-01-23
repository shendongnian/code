    private static Dictionary<string, string> configSPSynker;
    private static readonly object lockObject = new object();
    internal static bool TryGetValue(string key, out string value)
    {
        lock (lockObject)
        {
            // check inside the lock, because a race condition can occur.
            if (configSPSynker == null)
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var k in ConfigurationManager.AppSettings.AllKeys)
                {
                    if (k.Length > 9 && k.Substring(0, 9) == "SPSynker_")
                        dictionary.Add(k.Substring(9),
                                       ConfigurationManager.AppSettings[k]);
                }
                configSPSynker = dictionary;
            }
        }
        return configSPSynker.TryGetValue(key, out value);
    }
