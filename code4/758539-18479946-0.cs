    private Uri _ImageSource;
        public Uri ImageSource
        {
            get
            {
                return _ImageSource;
            }
            set
            {
                _ImageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            ImageSource = new Uri("/Assets/loading.gif", UriKind.Relative);
            this.DataContext = this;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
