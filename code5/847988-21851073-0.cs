    public class First : INotifyPropertyChanged
    {
        public int A { get; set; }
        public int AA { get {return A + 1; } }
        (...) // INotifyPropertyChanged implementation
    }
    public class Second : INotifyPropertyChanged
    {
        private First first;
        public Second(First first)
        {
            this.first = first;
            this.first.PropertyChanged += (s,e) => { FirstPropertyChanged(e.PropertyName);
            public int B { get {return first.A + 1; } }
            protected virtual void FirstPropertyChanged(string propertyName)
            {
                if (propertyName == "A")
                    NotifyPropertyChanged("B");
            }
            (...) // INotifyPropertyChanged implementation
        }
    };
