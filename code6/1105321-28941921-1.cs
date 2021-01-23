    namespace Demo
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {            
            public MainWindow()
            {            
                InitializeComponent();
                for (var i = 0; i < 5; i++)
                {
                    MyPanel.Children.Add(new Rectangle
                    {
                        Width = 100,
                        Height = 20,
                        StrokeThickness = 1,
                        Stroke = new SolidColorBrush(Colors.Black),
                        Margin = new Thickness(5)
                    });
                }
            }              
        }
    }
