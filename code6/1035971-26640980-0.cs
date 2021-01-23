    public static class ConfiguraCuadros
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> GetDictionary()
        {
            // Try to get the result in the static Dictionary
            return _configcuadros;
        }
    
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> GetHoja(string key)
        {
            // Try to get the result in the static Dictionary
            Dictionary<string, Dictionary<string, Dictionary<string, string>>> result = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
            if (_configcuadros.TryGetValue(key, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    
        public static readonly Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> _configcuadros = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> 
            {
                {   "Formato01",   //this is just a hint, the dictionary is much more extensive
                    new Dictionary<string, Dictionary<string, Dictionary<string, string>>> 
                        {
                            {
                                "F01C01A",      
                                new Dictionary<string, Dictionary<string, string>> 
                                {
                                    {
                                        "X",
                                        new Dictionary<string, string>
                                        {
                                            { "key1" , "value1" },
                                            { "key2" , "value2" },
                                            { "key3" , "value3" },
                                        }
                                    },
                                }
                            }
                         }
                  }
            };
    }
