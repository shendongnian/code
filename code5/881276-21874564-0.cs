     public class Configuration
        {
            private static Configuration _me;
    
            public static Configuration Settings
            {
                get
                {
                    if (_me == null)
                    {
                        _me = new Configuration();
                    }
                    return _me;
                }
            }
    
            // Properties
            public string Title { get; set; }
            public string Description { get; set; }
       }
    }
