    public class Employee
    {
        public string Name {get; set;}
    
		private Address _homeAddress;
        
		// only contains a getter, which auto-initializes the value to avoid NullReferenceException
                // this auto initialization is also useful to declutter your constructors
		public Address HomeAddress
        {
            get { return _homeAddress ?? (_homeAddress = new Address()); }
        }
    
        public class Address
        {
			// only classes from the same assembly can create addresses
			internal Address() {}
					
            public string Street {get; set;}
        }
    }
