    public class MyMainViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ImageSource _currentImage;
        public ImageSource CurrentImage 
        {
            get
            {
                return _currentImage ;
            }
            set
            {
                _currentImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }
        public void NextImage()
        {
            // here come the code that load the next image, as ever you see it fit
            //CurrentImage = ....
        }
    }
