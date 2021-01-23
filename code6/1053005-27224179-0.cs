    // In C#, the common convention is to give classes CamelCased names:
    public class Velocity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            // Local variables and method arguments are also camelCased,
            // but they start with a lower-case character:
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        // Properties with default getters and setters automatically get a 'backing field',
        // but we can't use that because we need to call OnPropertyChanged, so we'll have to
        // manually write out things. Normally, you'd give the backing field a name similar
        // to the property, so it's obvious that they belong together:
        private double _magnitude;
        public double Magnitude
        {
            get { return _magnitude; }
            set
            {
                _magnitude = value;
                // Here, you need to pass in the *name* of the property that's being changed,
                // so WPF knows which views it needs to update (WPF can fetch the new value
                // by itself):
                OnPropertyChanged("Magnitude");
            }
        }
    }
