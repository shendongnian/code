        SampleDomainContext _Service = new SampleDomainContext();
        public Sample()
        {
            _Service.Load(_Service.GetCustomersQuery());
            _Service.Customers.PropertyChanged += PropChanged;
            //_Service.Orders.PropertyChanged += PropChanged;
            // etc.
        }
        public int AddedEntitiesCount
        {
            get { return _Service.EntityContainer.GetChanges().AddedEntities.Count; }
        }
        public int ModifiedEntitiesCount
        {
            get { return _Service.EntityContainer.GetChanges().ModifiedEntities.Count; }
        }
        public int RemovedEntitiesCount
        {
            get { return _Service.EntityContainer.GetChanges().RemovedEntities.Count; }
        }
        public void PropChanged(object sender, PropertyChangedEventArgs e)
        {
            var pc = this.PropertyChanged;
            if (pc != null)
            {
                pc(this, new PropertyChangedEventArgs("AddedEntitiesCount"));
                pc(this, new PropertyChangedEventArgs("ModifiedEntitiesCount"));
                pc(this, new PropertyChangedEventArgs("RemovedEntitiesCount"));
                // etc
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
