    public Customer : ViewModel
    {
        public Address Address {get; set;} //this implements inpc but I don't show that here.
        public Customer()
        {
            // I get nothing here. But why?
            Address.PropertyChanged += (o, e) => OnPropertyChange(e.PropertyName);
    
            // What I want to do is get Customer propertychange to fire
            // Because currently Address changes are not detected.
        }
    }
