    class User : IClonable
    {
        public int Id { get; set; }
        public Dictionary<int, double> Neg { get; set; }
    
        public object Clone()
        {
        	// define a new instance
    		var user = new User();
    		
    		// copy the properties..
    		user.Id = this.Id;    
    		user.Neg = this.Neg.ToDictionary(k => k.Key,
                                             v => v.Value);
    
    		return user;
        }
    }
