        public ParentClass()
        {       
         this.PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            // Properties that are bound to the UI you want to update
            OnPropertyChanged("PROPERTYNAME");
        }
