    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public class NewConfigClass
            {
                public string MyConfigParameter {get;set;}
            }
    
            public class LegacyNeedsConfig
            {
                public string ConfigurableSetting {get;set;}
                public LegacyNeedsConfig(NewConfigClass config)
                {
                    this.ConfigurableSetting = config.MyConfigParameter;
                }
            }
    
            static void Main(string[] args)
            {
                NewConfigClass config = new NewConfigClass();
                config.MyConfigParameter = "hello world"; //read from web or app config
    
                LegacyNeedsConfig legacy = new LegacyNeedsConfig(config);
    
                Console.WriteLine(legacy.ConfigurableSetting);
            }
    
        }
    }
