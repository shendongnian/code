    namespace WpfApplication13
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                ImageUrl = "http://stackoverflow.com/users/flair/2836444.png";
            }
    
            private string _imageUrl;
            public string ImageUrl
            {
                get { return _imageUrl; }
                set { _imageUrl = value; INotifyPropertyChanged("ImageUrl"); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void INotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
