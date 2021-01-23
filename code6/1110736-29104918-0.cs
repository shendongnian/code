    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageGrid ig = new ImageGrid();
            Grid.Children.Add(ig);
            ig.Loaded += ImageGrid_Loaded;
           
        }
        void ImageGrid_Loaded(object sender, RoutedEventArgs e)
        {
             ig.DrawGrid();
        }
    }
    
