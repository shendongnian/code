       public partial class MainWindow : Window
        {
            private bool _isActive;
            public MainWindow()
            {
                InitializeComponent();
                StartXmlRefresher(5000);
            }
            private void StartXmlRefresher(int sleepMilliseconds)
            {
                _isActive = true;
                Task.Run(() =>
                    {
                        while (_isActive)
                        {
                            RefreshXml();
                            if(_isActive) Thread.Sleep(sleepMilliseconds);
                        }
                    });
            }
            private void RefreshXml()
            {
                Console.WriteLine(@"Refresh started");
                // your stuff here
                Console.WriteLine(@"Refresh completed");
            }
        }
