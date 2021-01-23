    namespace MyBA_UI
    {
        public class MyBA : BootstrapperApplication
        {
            protected override void Run()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Mainform(this));
            }
        }
    }
