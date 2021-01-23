    public class ImageViewModel : INotifyPropertyChanged
    {
        public string ImagePath { get; set; }
        public Visibility Visibility
        {
            get { return _vis; }
            set
            {
                _vis = value;
                RaisePropertyChanged("Visibility");
            }
        }
        private Visibility _vis = Visibility.Collapsed;
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(prop));
        }
    }
