    namespace WpfApplication14
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ObservableCollection<MyImage> _images = new ObservableCollection<MyImage>();
            private MyImage _selectedImage;
    
            public MainWindow()
            {
                InitializeComponent();
                foreach (var image in Directory.GetFiles(@"C:\Users\adacla\Pictures"))
                {
                    Images.Add(new MyImage { Path = image, Name = System.IO.Path.GetFileNameWithoutExtension(image) });
                }
            }
    
            public ObservableCollection<MyImage> Images
            {
                get { return _images; }
                set { _images = value; }
            }
    
            public MyImage SelectedImage
            {
                get { return _selectedImage; }
                set { _selectedImage = value; NotifyPropertyChanged("SelectedImage"); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    
        public class MyImage
        {
            public string Name { get; set; }
            public string Path { get; set; }
        }
    }
