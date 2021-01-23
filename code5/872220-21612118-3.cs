    public partial class Window1 : Window
    {
        List<BitmapSource> _animationSeq;
        public Window1()
        {
            InitializeComponent();
        }
        public void LoadImages()
        {
            _animationSeq = new List<BitmapSource>();
            string str = ".Images.whiteboard";
            string str2 = ".png";
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            for (int i = 0; i <= 300; i++)
            {
                string filename = string.Format("{0}{1}{2}{3}", this.GetType().Namespace, str, i.ToString("000"), str2);
                BitmapImage item = new BitmapImage();
                item.BeginInit();
                item.StreamSource = executingAssembly.GetManifestResourceStream(filename);
                item.CacheOption = BitmapCacheOption.OnLoad;
                item.CreateOptions = BitmapCreateOptions.None;
                item.EndInit();
                item.Freeze();
                _animationSeq.Add(item);
            }
            sequencer.Load(_animationSeq);
            sequencer.Play();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImages();
        }
    }
