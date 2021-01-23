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
                // Remove the event subscription from the old instance.
                if (old != null) old.PropertyChanged -= objectA_PropertyChanged;
                // Add the event subscription to the new instance.
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
