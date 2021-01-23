        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponents();
            // ... the rest
            // possibly app.MainWindow = start; or app.MainWindow = next;
            // if only 1 window, then app.Run(new MainWindow());
        }
