    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadProc();
            Application.Run(); // Keep on running!
        }
        private static void ThreadProc()
        {
            if (System.Windows.Application.Current == null)
                new System.Windows.Application();
            System.Diagnostics.Trace.WriteLine("howdy");
            try
            {
                string assemblyName = string.Format("{0}\\AutoUpdateTesting.dll", new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName);
                System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Window wnd = LoadAssembly(assemblyName, "OtherWindow");
                    wnd.Show();
                }));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Failed to load window from{0} - {1}", "OtherWindow", ex.Message));
            }
        }
        private static Window LoadAssembly(String assemblyName, String typeName)
        {
            try
            {
                Assembly assemblyInstance = Assembly.LoadFrom(assemblyName);
                foreach (Type t in assemblyInstance.GetTypes().Where(t => String.Equals(t.Name, typeName, StringComparison.OrdinalIgnoreCase)))
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
