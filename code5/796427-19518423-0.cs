    public class Point2D : INotifyPropertyChanged
    {    
        public event PropertyChangedEventHandler PropertyChanged;
        private double _x;
        private double _y;    
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                NotifyPropertyChanged("X");
            }
        }
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                NotifyPropertyChanged("Y");
            }
        }
           
        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }    
    }
