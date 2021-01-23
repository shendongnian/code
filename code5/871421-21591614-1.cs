    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                SelectedPersonsGridView.Background = Brushes.Red;
            }
        }
    }
