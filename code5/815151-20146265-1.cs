    public class WindroseWindDirection : INotifyPropertyChanged
    {
        private string _direction;
        private short _directionValue;
    
        #region Construction
    
        public WindroseWindDirection() : this("not available",0) {}
    
        public WindroseWindDirection(string direction, short defaultDirectionValue)
        {
            _direction = direction;
            _directionValue = defaultDirectionValue;
        }
    
        #endregion
    
        #region Properties
    
        public string Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if (String.Compare(_direction, value) != 0)
                {
                    _direction = value;
                    OnPropertyChanged("Direction");
                }
    
            }
        }
        public short DirectionValue
        {
            get
            {
                return _directionValue;
            }
            set
            {
                if (_directionValue != value)
                {
                    OnPropertyChanged("DirectionValue");
                    _directionValue = value;
                }                
            }
        }
    
        #endregion
    
        #region INotifyPropertyChanged implementation
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        #endregion
    }
