    public partial class MyPictureControl : UserControl
    {
        public MyPictureControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(MyPictureControl), new PropertyMetadata(null));
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
    }
