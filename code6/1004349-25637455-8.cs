    static class Program
        {
            public static Form GlobalMainForm;
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                GlobalMainForm = new Form1();
                Application.Run(GlobalMainForm);
            }
        }
