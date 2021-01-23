    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                // simulate some long work
                IProgress<double> progress = new Progress<double>(handler);
                Action action = () =>
                {
                    int length = 10;
                    for (int i = 0; i < length; i++)
                    {
                        Thread.Sleep(3000);
                        double d = 1.0d/length*(i + 1);
                        progress.Report(d);
                    }
                };
    
                await Task.Run(action);
            }
    
            private void handler(double value)
            {
                ProgressBar.Value = value*100;
            }
        }
    }
