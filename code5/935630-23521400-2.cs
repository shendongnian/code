    public ClassA
    {
        public ClassA()
        {
            MySingleton.PropertyChanged += Singleton_PropertyChanged;
        }
    
        void Singleton_PropertyChanged(object sender, NotifyPropertyChangedEventArgs e)
        {
            // if singleton's Number property changed, raise change 
            // notification for this class's Number property too
            if (e.PropertyName == "Number")
                OnPropertyChanged("Number");
        }
    
        public int Number 
        {
            get { return MySingleton.Number; }
            set { MySingleton.Number = value; }
        }
    }
