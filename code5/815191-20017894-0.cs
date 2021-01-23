    internal class MyClass : INotifyPropertyChanged
    {
        private bool _isOdd;
        public bool IsOdd 
        {
            get
            {
                return _isOdd;
            }
            set
            {
                _isOdd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsOdd"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Color"));
                }
            }
        }
        public Color Color
        {
            get
            {
                return (IsOdd) ? Color.Green : Color.Red;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
