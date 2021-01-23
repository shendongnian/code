    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // download my dogecoin image
            myImage.Source = new BitmapImage(new Uri("http://www.chubosaurus.com/dogecoin_wp8.jpg", UriKind.Absolute));           
            // hook the download complete 
            myImage.ImageOpened += bi_ImageOpened;
        }
        // image has downloaded completely, do your actions afterwards
        void bi_ImageOpened(object sender, RoutedEventArgs e)
        {
            // ..... your code
            // put a break point here, you will see it will break when the image has downloaded
        }
     }
