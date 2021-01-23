    public class SomeClass : INotifyPropertyChanged
    {
        public int A
        {
            get { return a; }
            set 
            {
                if (a != value)
                {
                    a = value;
                    OnPropertyChanged("A");
                }
            }
        }
        private int a;
        public int B
        {
            get { return b; }
            set 
            {
                if (b != value)
                {
                    b = value;
                    OnPropertyChanged("B");
                }
            }
        }
        private int b;
        public int C
        {
            get { return c; }
            private set
            {
                if (c != value)
                {
                    c = value;
                    OnPropertyChanged("C");
                }
            }
        }
        private int c;
        // INotifyPropertyChanged implementation
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            
            // update calculated property
            if (propertyName == "A" || propertyName == "B")
            {
                // this will cause binding target to re-read C value
                C = A + B;
            }
        }
    }
