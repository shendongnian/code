        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmMain()); - Old method
            Application.Run(frmMain.GetMain());
        }
