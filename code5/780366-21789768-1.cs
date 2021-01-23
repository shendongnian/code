     static class Program
        {
    
            static MainForm mainForm;
            [STAThread]
            static void Main(params string[] Arguments)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                mainForm = new MainForm(Arguments);
                SingleInstanceApplication.Run(mainForm, NewInstanceHandler);
    
            }
    
            public static void NewInstanceHandler(object sender, StartupNextInstanceEventArgs e)
            {
                mainForm.FileName(e.CommandLine[1]);
    
                e.BringToForeground = false;
            }
    
            public class SingleInstanceApplication : WindowsFormsApplicationBase
            {
                private SingleInstanceApplication()
                {
                    base.IsSingleInstance = true;
    
                }
    
                public static void Run(RibbonForm f, StartupNextInstanceEventHandler startupHandler)
                {
                    SingleInstanceApplication app = new SingleInstanceApplication();
                    app.MainForm= f;
                    if (f.DialogResult != DialogResult.Cancel)
                    {
                        app.StartupNextInstance += startupHandler;
                        app.Run(Environment.GetCommandLineArgs());
                    }
                }
    
    
                
            }
    //add this to MainForm
    public void FileName(string args)
     {  }
