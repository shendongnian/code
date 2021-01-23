    public partial class MainWindow : Window
    {
        public string imgSource
        {
            get { return (string)GetValue(imgSourceProperty); }
            set { SetValue(imgSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for imgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty imgSourceProperty =
            DependencyProperty.Register("imgSource", typeof(string), typeof(MainWindow));
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; 
            imgSource=@"your_image_url";
        }
    }
