        [STAThread()]
        internal static void Main()
        {
            // [Your startup code here]
            Application app = new Application();
            app.DispatcherUnhandledException += DispatcherUnhandledException;
            app.MainWindow = new MainWindow();
            app.MainWindow.ShowDialog();
            Console.WriteLine("Terminating...");
            Startup.FreeConsole();
            app.Shutdown(0);
            Environment.Exit(0);  // <-- a bit redundant however
        }
