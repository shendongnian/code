       public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
                int asciiCode = (int) e.NewValue + 65;
                lbl.Content = (char) asciiCode;
            }
        }
