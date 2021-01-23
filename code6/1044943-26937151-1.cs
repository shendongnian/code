    using System.Windows;
    
    namespace LB
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                lbOuter.SelectedIndex++;
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                lbInner.SelectedIndex++;
            }
        }
    }
