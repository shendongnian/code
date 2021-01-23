    public partial class Picture : UserControl
    {
        public Picture()
        {
            InitializeComponent();            
        }
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(Picture), new PropertyMetadata(string.Empty, new PropertyChangedCallback(ImagePathCallBack)));
        private static void ImagePathCallBack(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            Picture pic = obj as Picture;
            pic.image.Source= new BitmapImage(new Uri((string)args.NewValue));
        }
        public string ImageLabel
        {
            get { return (string)GetValue(ImageLabelProperty); }
            set { SetValue(ImageLabelProperty, value); }
        }
        
        public static readonly DependencyProperty ImageLabelProperty =
            DependencyProperty.Register("ImageLabel", typeof(string), typeof(Picture), new PropertyMetadata(string.Empty,new PropertyChangedCallback( ImageLabelCallBack)));
        private static void ImageLabelCallBack(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            Picture pic = obj as Picture;
            pic.imageName.Text= (string)args.NewValue;
        }        
    }
