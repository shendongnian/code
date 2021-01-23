    class Program
    {
        public static string key = "I am in the WRONG assembly.";
        static void Main(string[] args)
        {
            key = "I am in the primary assembly";
            plap pop = new plap();
            var appDir = AppDomain.CurrentDomain.BaseDirectory;
            //We have to create AppDomain setup for shadow copying 
            var appDomainSetup = new AppDomainSetup
                                 {
                                     ApplicationName = "", //with MSDN: If the ApplicationName property is not set, the CachePath property is ignored and the download cache is used. No exception is thrown.
                                     ShadowCopyFiles = "true",//Enabling ShadowCopy - yes, it's string value
                                     ApplicationBase = appDir,//Base path for new app domain - our plugins folder
                                     CachePath = "VSSCache",//Path, where we want to have our copied dlls store.                                      
                                 };
            Console.WriteLine("Looking for plugins in {0}\\Plugins", appDir);
            var apd = AppDomain.CreateDomain("My new app domain", null, appDir, "Plugins", true);
            
            //We are creating our plugin proxy/factory which will exist in another app domain 
            //and will create for us objects and return their remote 'copies'. 
            var proxy = (MyPluginFactory)apd.CreateInstance("PluginBaseLib", "PluginBaseLib.MyPluginFactory").Unwrap();
            
            var instance = proxy.CreatePlugin("SamplePlugin", "SamplePlugin.MySamplePlugin");
            Console.WriteLine("[appdomain:{0}] Main: subscribing for event from remote appdomain.", AppDomain.CurrentDomain.FriendlyName);
            instance.MyEvent += pop.EventReceiver;
            
            instance.TestEvent();
            Console.WriteLine("[appdomain:{0}] Main: Waiting for event (press return to continue).", AppDomain.CurrentDomain.FriendlyName);
            Console.ReadKey();
            instance.MyEvent -= pop.EventReceiver;
            Console.WriteLine("[appdomain:{0}] Main: Unloading appdomain: {1}", AppDomain.CurrentDomain.FriendlyName, apd.FriendlyName);
            AppDomain.Unload(apd);
            Console.ReadKey();
        }
    }
    class plap : MarshalByRefObject
    {
        public plap() { }
        public void EventReceiver(object sender, EventArgs e)
        {
            Console.WriteLine("[appdomain:{1}] Received an event from {0} [key: {2}]", sender.ToString(), AppDomain.CurrentDomain.FriendlyName, Program.key);
        }
    }
