    using log4net;
    [assembly: log4net.Config.XmlConfigurator(Watch = true)]
    namespace Litter
    {
        class Program
        {
            static void Main()
            {
                LogManager.GetLogger("default").Info("Hello, World!");
            }
        }
    }
