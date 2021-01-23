     public partial class MainWindow : Window
    {
        private ObservableCollection<ImageInfo> _images;
        public MainWindow()
        {
            InitializeComponent();
            _images = new ObservableCollection<ImageInfo>(GetImages());
            cbOne.ItemsSource = _images;
            cbTwo.ItemsSource = _images;
            cbThree.ItemsSource = _images;
            cbFour.ItemsSource = _images;
        }
        public IEnumerable<ImageInfo> GetImages()
        {
            const string path = @"C:\_D\_Log\";
            var items = from x in Directory.GetFiles(path, "*.png")
                        select new ImageInfo
                        {
                            ImageUrl = x,
                            Name = System.IO.Path.GetFileName(x)
                        };
            return items;
        }
    }
    public class ImageInfo
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
