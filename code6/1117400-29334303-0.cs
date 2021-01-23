    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Logger.Init();
            string assemblyName = Logger.AssemblyGuid; // to test under debug
        }
    }
