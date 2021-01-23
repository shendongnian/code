        private List<string> _images;
        /// <summary>
        /// List of images
        /// </summary>
        public List<string> Images
        {
            get { return _images; }
            set { _images = value; }
        }
        //selected image index
        public int SelectedImageIndex { get; set; }
        // Constructor
        public MainPage()
        {
          InitializeComponent();
          this.Loaded += MainPage_Loaded;
          this.DataContext = this;
        }
       void MainPage_Loaded(object sender, RoutedEventArgs e)
       {
            LoadImages();
            DispatcherTimer t = new DispatcherTimer();
            //setting a 5 second interval
            t.Interval = new TimeSpan(0, 0, 5); 
            t.Tick += t_Tick;
            t.Start();
        }
        void t_Tick(object sender, EventArgs e)
        {
            if (SelectedImageIndex-1 == Images.Count)
                SelectedImageIndex = 0;
            else
                SelectedImageIndex++;
            SetImageSource(Images[SelectedImageIndex]);
        }
        //Populating image list
        private void LoadImages()
        {
            if (Images == null)
                Images = new List<string>();
            Images.Add("/Image/aaa.jpg");
            Images.Add("/Image/bbb.jpg");
            Images.Add("/Image/ccc.jpg");
            Images.Add("/Image/ddd.jpg");
            SelectedImageIndex = 0;
            SetImageSource(Images[SelectedImageIndex]);
        }
        //setting image source
        private void SetImageSource(string imagePath)
        {
            Img.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        //image tap event
        private void Img_OnTap(object sender, GestureEventArgs e)
        {
            string selectedImagePath = Images[SelectedImageIndex];
            //put navigation here
        }
  
