    using System;
    using System.Threading;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void UpdateButtonClick(object sender, RoutedEventArgs e)
            {
                UpdateStatus("Searching for devices, please wait");
                var thread = new Thread(LoadDevices);
                thread.Start();
            }
    
            private void LoadDevices()
            {
                // Your long running "load devices" implementation goes here
                for (int i = 0; i < 15; i++)
                {
                    Dispatcher.BeginInvoke((Action) (() => UpdateStatus(".")));
                    Thread.Sleep(250);
                }
                Dispatcher.BeginInvoke((Action)(() => UpdateStatus(" done")));
            }
    
            private void UpdateStatus(string status)
            {
                TextStatus.AppendText(status);
            }
        }
    }
