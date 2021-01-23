    class OuterVm : Notifiable
    {
        public OuterVm()
        {
            // initialize _collection
            _collection.PropertyChanged += (o,e) =>
            {
                if (e.PropertyName == "Selected")
                    OnPropertyChanged("Display");
            };
        }
        CollectionVm _collection;
        public Vm Display
        {
            get {return _collection.Selected; }
        }
    }
