    // MainWindow.xaml.cs
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();    
            var mainWindowVm = new MainWindowViewModel();
            DataContext = mainWindowVm;
    
            byte[] buffer = File.ReadAllBytes(@"C:\temp\icon.jpg");
            string base64String = Convert.ToBase64String(buffer, 0, buffer.Length);
    
            // Option 1
            byte[] binaryData = Convert.FromBase64String(base64String);
            Icon.Source = MainWindowViewModel.LoadImage(binaryData);    
            // Option 2
            mainWindowVm.SetImageSource(Convert.FromBase64String(base64String));    
            // Option 3
            // mainWindowVm.SetImageSource(File.ReadAllBytes(@"C:\temp\icon.jpg"));
        }
    }
    
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ImageSource _imageSource;
    
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void SetImageSource(byte[] imageData)
        {
            // You can also call LoadImage from here.
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(imageData);
            image.EndInit();    
            ImageSource = image;
        }
    
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
