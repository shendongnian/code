    class Foo
    {
        public Guid FooId { get; private set; } // Only allow the object to define its Id.
        public List<Bar> Bars { get; set; } // Use a dynamic storage object.
    	private bool Deleted { get; set; } // Monitors if the object has been deleted in the DB.
    
        public Foo()
        {
            this.FooId = Guid.Empty;
    		this.Deleted = false;
            Bars = new List<Bar>();
        }
    
        public Foo(Guid fooId)
        {
    		this.Deleted = false;
    		
            this.FooId = fooId;
            LoadFromDatabase();
    		
            Bars = new List<Bar>();
            LoadBarsFromDatabase();
        }
    
        private void LoadFromDatabase()
        {
            // Read from DB, set local variables...
        }
    
        private void LoadBarsFromDatabase()
        {
            // Psuedocode to load all Bars.
            foreach (var barData in barIdsLinkedToFooTable.Rows)
            {
                Bars.Add(new Bar(this, barData["barId"]));
            }
        }
    
        public void SaveToDatabase()
        {
            // If FooId is Guid.Empty, the record is new.
    		// You may also want to consider the Deleted property value.
            // Either generate the new Guid first or let SQL do it for you in your SP.
    
            // Save Foo to DB with stored proc.
    
            // Save Bars.
            foreach (var bar in Bars)
            {
                bar.SaveToDatabase();
            }
        }
    	
    	public void Delete()
    	{
    		// Delete via a stored proc.
    		// Might be a good idea to set SQL to cascade the delete,
    		//  this way all the children will be deleted automatically.
    		
    		this.Deleted = true;
    	}
    }
    
    class Bar
    {
        public Guid BarId { get; private set; } // Only allow the local object to generate Id.
        public Foo ParentFoo { get; set; } // Store a reference to the parent.
        public List<Baz> Bazs { get; set; } // Use a dynamic storage object.
    	private bool Deleted { get; set; } // Monitors if the object has been deleted in the DB.
    	
    	public Bar(Foo parentFoo)
    	{
    		// New Bar object.
    		this.BarId = Guid.Empty;
    		this.ParentFoo = parentFoo;
    		this.Bazs = new List<Baz>();
    		this.Deleted = false;
    	}
    	
    	public Bar(Foo parentFoo, Guid barId)
    	{
    		// Create from existing object.
    		this.Deleted = false;
    		
    		this.BarId = barId;
    		this.ParentFoo = parentFoo;
            LoadFromDatabase();
    		
            Bazs = new List<Baz>();
            LoadBazsFromDatabase();
    	}
    	
    	/* DB methods for load, save, and delete similar to above. */
    }
