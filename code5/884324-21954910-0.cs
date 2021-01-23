        void Window3_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSourceFiles();
            StartTimer();
        }
        void StartTimer()
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Tick += dt_Tick;
            dispatcherTimer.IsEnabled = true;
        }
        void LoadSourceFiles()
        {
            if (!System.IO.Directory.Exists(DestinationDir))
            {
                System.IO.Directory.CreateDirectory(DestinationDir);
            }
            if (System.IO.Directory.Exists(SourceDir))
            {
                SourceFiles = Directory.GetFiles(SourceDir).ToList();
            }
        }
