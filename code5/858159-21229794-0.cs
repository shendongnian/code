    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (runNormally(args))
            {
                MainWindow mainWindow = new MainWindow();
                var app = new Application();
                app.Run(mainWindow);
            }
            else
            {
                MyFunction(args);
            }
        }
    }
