    public class Person 
     {
       public int PersonID { get; set; }
       public string FirtName { get; set; }
       public string LastName { get; set; }
    
	   public virtual PersonAddress PersonAddress { get; set; }
     }
     public class PersonAddress
     {
        [Key, ForeignKey("Person")]    
        public int PersonID { get; set; }   
        public string Street { get; set; }
        public string Town { get; set; }    
	
	    public virtual Person Person { get; set; }
     }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
	    // Configure PersonId as PK for PersonAddress
	    modelBuilder.Entity<PersonAddress>()
		.HasKey(e => e.PersonId);
	
	   // Configure PersonId as FK for PersonAddress
	     modelBuilder.Entity<Person>()
				.HasOptional(s => s.PersonAddress) // Mark PersonAddress is           optional for Person
				.WithRequired(ad => ad.Person); // Create inverse relationship
     }
