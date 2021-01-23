    class Program
    {
    	static void Main(string[] args)
    	{
    		Person p1 = new Person { FirstName = "Manny", Birthday = new DateTime(1970, 1, 4) };
    		Person p2 = new Person { FirstName = "Moe", Birthday = new DateTime(1970, 1, 4) };
    		Person p3 = new Person { FirstName = "Manny", Birthday = new DateTime(1970, 1, 4) };
    
    		Console.WriteLine("p1 = p2? {0}", p1.Equals(p2));
    		Console.WriteLine("p2 = p3? {0}", p2.Equals(p3));
    		Console.WriteLine("p1 = p3? {0}", p1.Equals(p3));
    
    		Console.WriteLine("p1 Hash = {0}", p1.GetHashCode());
    		Console.WriteLine("p2 Hash = {0}", p2.GetHashCode());
    		Console.WriteLine("p3 Hash = {0}", p3.GetHashCode());    
    	}
    }
    
    class Person
    {
    	public string FirstName { get; set; }
    	public DateTime Birthday { get; set; }
    
    	// You define what an equaled object is. 
        // In this example, we will say a Person is equal if they have the same
        // FirstName and Birthday
        public override bool Equals(object obj)
    	{
    		bool equals = false;
    		if (obj is Person)
    		{
    			Person p = (Person)obj;
    			if (p.FirstName == this.FirstName && p.Birthday == this.Birthday)
    				equals = true;
    		}
    		return equals;
    	}
    
    	// You define what the hashcode of the object is. 
        // In this example, we will define the hashcode as the 
        // concatenation of the FirstName and Birthday
        public override int GetHashCode()
    	{
    		return string.Format("{0}-{1}", this.FirstName, this.Birthday).GetHashCode();
    	}
    }
