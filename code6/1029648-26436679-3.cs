    // Constructor
    public MainPage()
    {
        InitializeComponent();
        Image mytestimage = new Image();
        mytestimage.Visibility = System.Windows.Visibility.Collapsed;
        mytestimage.Source = new BitmapImage(new Uri("http://www.chubosaurus.com/dogecoin_wp8.jpg", UriKind.Absolute));           
        // add it to the Visual Tree as a child of ContentPanel
        this.ContentPanel.Children.Add(mytestimage);
        // hook the download complete
        mytestimage.ImageOpened += mytestimage_ImageOpened;            
    }
    // image has been downloaded successfully
    void mytestimage_ImageOpened(object sender, RoutedEventArgs e)
    {            
        // your code
    }
