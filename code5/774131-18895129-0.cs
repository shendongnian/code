    class Relation
    {
        private readonly EfRelation _originalRelation;
        public Relation(EfRelation originalRelation)
        {
            this._originalRelation = originalRelation;
        }
        public string Devices 
        { 
            get { return this._originalRelation.devices.device_name; } 
            set { this._originalRelation.devices.device_name = value; } 
        }
        // Repeat for other properties
    }
    ...
    
    var reltables = (from r in entities.relations orderby r.id select new Relation(r)).ToList();
