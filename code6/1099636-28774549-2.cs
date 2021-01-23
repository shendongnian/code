    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainFormInstance = null;
            var splash = new SplashForm<MainForm>();
            splash.MainFormLoaded +=
                (s, e) =>
                {
                    mainFormInstance = e;
                    splash.Dispose();
                };
            Application.Run(splash);
            Application.Run(mainFormInstance);
        }
    }
