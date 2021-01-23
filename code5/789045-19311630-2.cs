    public class Point2D : INotifyPropertyChanged
    {
        private double x;
        private double y;
        public double X
        {
            set
            {
                if (value.Equals(x)) return;
                x = value;
                OnPropertyChanged();
            }
            get { return x; }
        }
        public double Y
        {
            set
            {
                if (value.Equals(y)) return;
                y = value;
                OnPropertyChanged();
            }
            get { return y; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
