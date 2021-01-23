    public class K
    {
        public void Run()
        {
            //var f1 = Assembly.GetAssembly(typeof (K)).CreateInstance("Plugin.K");
            //var f2 = Assembly.GetExecutingAssembly().CreateInstance("Plugin.K");
            //var f3 = Activator.CreateInstance(typeof(K));
            //won't throw exception
            var x = Activator.CreateInstance(null, "Plugin.K");
        }
    }
