        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1].Equals("--cleanup-only"))
            {
                // Desktop cleanup code, without GUI
            }
            else
            {
                // Normal execution
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
