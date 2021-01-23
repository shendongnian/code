        public string SomeProperty
        {
            get { return MyItem.SomeProperty; }
            set
            {
                MyItem.SomeProperty = value;
                OnPropertyChanged(); // <-- no need for property name anymore
            }
        }
