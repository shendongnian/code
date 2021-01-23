    class Company
    {
    	public string Name { get; set; }
    	public Person Contact { get; set; }
    	public Address HQAddress { get; set; }
    }
    
    class Address
    {
    	public string City { get; set; }
    	public string Country { get; set; }
    }
    
    // Define other methods and classes here
    class Person
    {
       public string Name { get; set; }
       public DateTime DOB { get; set; }
       public int Height { get; set; }
       public float Weight { get; set; }
    }
