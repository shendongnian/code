    using System.Threading;
    using System.Windows;
    using System.Windows.Media;
    namespace TestWPF
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                int duration = 10; //Change this number to change the total flash duration
                double interval = 0.5; //Change this number to increase/decrease the interval between color changes.
                Thread t = new Thread(() => FlashColor(duration, interval));
                t.Start();
            }
            private void FlashColor(int duration, double interval)
            {
                for (int counter = 0; counter < (int) (duration/interval); counter++)
                {
                    Dispatcher.Invoke(() => ChangeColor(Brushes.White));
                    Thread.Sleep((int) (interval*1000));
                    Dispatcher.Invoke(() => ChangeColor(Brushes.Red));
                    Thread.Sleep((int) (interval*1000));
                }
            }
            public void ChangeColor(SolidColorBrush color)
            {
                MyTextBox.Background = color;
            }
        }
    }
