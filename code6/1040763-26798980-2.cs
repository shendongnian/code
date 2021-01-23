    public class Angle : INotifyPropertyChanged
    {
        private float _deg;
        private float _rad;
        public event PropertyChangedEventHandler PropertyChanged;
        public Angle() { }
        public Angle(float deg, float rad)
        {
            this.Deg = deg;
            this.Rad = rad;
        }
        public float Deg
        {
            get
            {
                return _deg;
            }
            set
            {
                _deg = value;
                OnPropertyChanged("Deg");
            }
        }
        public float Rad
        {
            get
            {
                return _rad;
            }
            set
            {
                _rad = value;
            }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
    
