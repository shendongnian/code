    public class S : INotifyPropertyChanged
    {
        private string name, ID;
        private A objectA;
        public A ObjectA
        {
            get { return objectA; }
            set
            {
                var old = objectA;
                objectA = value;
                if (old != null) old.PropertyChanged -= objectA_PropertyChanged;
                if (objectA != null) objectA.PropertyChanged += objectA_PropertyChanged;
                OnPropertyChanged("ObjectA");
            }
        }
        void objectA_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Propagate the change to any listeners. Prefix with ObjectA so listeners can tell the difference.
            OnPropertyChanged("ObjectA." + e.PropertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
