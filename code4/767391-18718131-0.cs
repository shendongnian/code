    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private DateTime? StartTime;
            public MainWindow()
            {
                InitTimers(); 
                InitializeComponent();
            }
            private void btnStart_Click(object sender, RoutedEventArgs e)
            {
                StartTime = DateTime.Now;
            }
            private void InitTimers()
            {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += DispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
            private void DispatcherTimer_Tick(object sender, EventArgs e)
            {
                if (StartTime != null) //Always null
                    lbElipsedTime.Content = DateTime.Now - StartTime;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
