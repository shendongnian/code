     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                InitializeImages();
                DataContext = this;
    
            }
    
            private void InitializeImages()
            {
                ImageModels.Add(new ImageModel
                {
                    Source = new BitmapImage(new Uri("/ProjectDemo;component/images/highway.png", UriKind.Relative))
                });
                ImageModels.Add(new ImageModel
                {
                    Source = new BitmapImage(new Uri("/ProjectDemo;component/images/highway-1.png", UriKind.Relative))
                });
                ImageModels.Add(new ImageModel
                {
                    Source = new BitmapImage(new Uri("/ProjectDemo;component/images/part-5.png", UriKind.Relative))
                });
            }
    
    
            ObservableCollection<ImageModel> _imageModels = new ObservableCollection<ImageModel>();
    
            ObservableCollection<ImageModel> ImageModels
            {
                get { return _imageModels; }
            }
        }
    
        public class ImageModel : INotifyPropertyChanged
        {
            private ImageSource imageSource;
    
            public ImageSource Source
            {
                get { return imageSource; }
                set
                {
                    imageSource = value;
                    RaisePropertyChanged("Source");
                }
            }
    
            private void RaisePropertyChanged(string propName)
            {
                if(PropertyChanged != null)
                {
                    PropertyChanged(this,new PropertyChangedEventArgs(propName));
                }
            }
        
    
        public event PropertyChangedEventHandler PropertyChanged;
        }
