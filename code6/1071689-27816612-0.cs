        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += Application_ApplicationExit;
            AppDomain.CurrentDomain.ProcessExit += Application_ApplicationExit;
            Application.Run(new Form1());
        }
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //Do something
        }
