      *Example :*
    
        public sealed partial class MainPage : Page, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        private string imgArt;
    
        public string ImgArt
        {
            get { return imgArt; }
            set { imgArt = value; OnPropertyChanged("ImgArt"); }
        }
