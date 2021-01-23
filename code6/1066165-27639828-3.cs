    public class RadialGougeViewModel : INotifyPropertyChanged
    {
        private int _angle;
        public int Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                OnPropertyChanged("Angle");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
         
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
