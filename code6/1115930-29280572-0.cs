    public class User : INotifyPropertyChanged
    {       
        public string _Color;
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                NotifyPropertyChanged();
            }
        }        
    }
