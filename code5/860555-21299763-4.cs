    static class Program
    {
        public static MainWindow MainWindow { get; private set; }
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.MainWindow = new MainWindow();
            Application.Run(Program.MainWindow);
        }
    }
