    public partial class App : Application
    {
        App()
        {
            Startup += App_Startup;
        }
        void App_Startup(object sender, StartupEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("howdy");
            try
            {
                string assemblyName = string.Format("{0}\\AutoUpdateTesting.dll", new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName);
                Window wnd = LoadAssembly(assemblyName, "OtherWindow");
                wnd.Show();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Failed to load window from{0} - {1}", "OtherWindow", ex.Message));
            }
        }
        private Window LoadAssembly(String assemblyName, String typeName)
        {
            try
            {
                Assembly assemblyInstance = Assembly.LoadFrom(assemblyName);
                foreach (Type t in assemblyInstance.GetTypes().Where(t => t.Name == typeName))
                {
                    var wnd = assemblyInstance.CreateInstance(t.FullName) as Window;
                    return wnd;
                }
                throw new Exception("Unable to load external window");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Failed to load window from{0}{1}", assemblyName, ex.Message));
                throw new Exception(string.Format("Failed to load external window{0}", assemblyName), ex);
            }
        }
    }
