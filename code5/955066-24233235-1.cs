    using System.Windows;
    
    namespace WpfApplication9
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void tb1_Loaded(object sender, RoutedEventArgs e)
            {
                tb1.Width = tb1.ActualWidth;
            }
        }
    }
