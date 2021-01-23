        public string SomeProperty
        {
            get { return MyItem.SomeProperty; }
            set
            {
                MyItem.SomeProperty = value;
                OnPropertyChanged("SomeProperty");
            }
        }
    You should prefer binding to the ViewModel if you want to follow MVVM practices.
