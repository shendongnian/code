                // load the window
            var main = new MainWindow();
            // initialize the hWnd
            InitHwnd(main);
            // attach the viewmodel
            ApplicationViewModel context = new ApplicationViewModel();
            main.DataContext = context;
            // ?load the login screen
            if (StorageManager.EnableLogin)
                DisplayLoginScreen(main);
            else
                main.Show();
