    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace WpfApplication7
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                for (var i = 0; i < 20000; i++)
                {
                    var l = new Line
                    {
                        X1 = 10,
                        Y1 = 10,
                        X2 = 10,
                        Y2 = 100,
                        Stroke = Brushes.White
                    };
    
                    canvas.Children.Add(l);
                }
            }
    
            private void btnRemove_Click(object sender, RoutedEventArgs e)
            {
                canvas.Children.Clear();
            }
        }
    }
