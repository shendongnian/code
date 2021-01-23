    public MainClass()
    {
        // just using auto-properties here. Will need initialized before use.
        public ChildClass cc { get; set; }
        public OtherChild oc { get; set; }
         // Constructor. Gets called when initializing as "new MainClass()"
         public MainClass() 
         {                
			// initialize our properties
			
			// option 1 - initialize, then set
			cc = new ChildClass();
			cc.childName = "some name"; //Set the name property of childclass
			
			//option 2 - initialize and set via constructor
			cc = new ChildClass("some name");
			
			// option 3 - initialize and set with initializer (more here: http://msdn.microsoft.com/en-us/library/vstudio/bb397680.aspx)
			cc = new ChildClass() { name = "some name" };
			
			oc = new OtherChild(cc);
         }
    }
    public ChildClass()
    {
        public string name { get; set; }
        
        // Default constructor. this.name will = null after this is run
        public ChildClass() 
        {                
        }
        
        // Other constructor. this.name = passed in "name" after this is run
        public ChildClass(string name) 
        {
			//"this.name" specifies that you are referring to the name that belongs to this class
			this.name = name;
        }
        
    }
    public OtherChild()
    {
        public ChildClass cc { get; set; } 
         
        public OtherChild() 
        {        
		   cc = new ChildClass(); // initialize object in the default constructor
        }
         
        public OtherChild(ChildClass childClass) 
        {        
		   cc = childClass; // set to the reference of the passed in childClass
        }
    }
