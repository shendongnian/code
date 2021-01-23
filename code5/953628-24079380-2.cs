    public class RandomColorGeneratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Color> _colorList;
        public List<Color> ColorList
        {
            get { return _colorList; }
            set { _colorList = value; }
        }
    }
