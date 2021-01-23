        using System.Threading.Tasks;
        using log4net;
        using System.Text;
        using System.CollectionsGeneric;
        using System;
        namespace Log4NetTest
        {
            class Program
            {
        
                private static readonly ILog _logger = LogManager.GetLogger("testApp.LoggingExample");
        
                static void Main(string[] args)
                {
                    // Configure from App.config. This is marked as obsolete so you can also add config into separate config file
                    // and use log4net.Config.XmlConfigurator method to configure from xml file.            
                    log4net.Config.DOMConfigurator.Configure(); 
        
                    _logger.Debug("Shows only at debug");
                    _logger.Warn("Shows only at warn");
                    _logger.Error("Shows only at error");
        
                    Console.ReadKey();
                }
            }
        }
