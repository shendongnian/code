    public void PersonViewModel()
    {
        // Will be used when no model is available - create mode
        public PersonViewModel()
            : this(null) { }
    
        // Will be used when a model is available - edit mode
        public PersonViewModel(IPerson person) 
        { 
            // Here you check if you have a person object, if so, edit 
        }
    }
