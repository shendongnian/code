    class PublicSettings
        {        
            private static string _ConnStr = "Connection";
    
            public static string ConnStr
            {
                get
                {
                    return _ConnStr;
                }
                set
                {
                    _ConnStr = value;
                }
            }
        }
