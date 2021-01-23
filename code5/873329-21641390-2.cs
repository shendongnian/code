    public class Car
    {
    	public virtual int CarId { get; set; }
    	public virtual string Name { get; set; }
    	public virtual IList<Part> AllParts {get; set;}
    
    	public Car()
    	{
    		AllParts = new List<Part>();
    	}
    }
    
    public class Part
    {
    	public virtual int PartId { get; set; }
    	public virtual string Name { get; set; }
    	public virtual IList<Car> AllCars {get; set;}
    	
    	//never tried mapping a many-to-many on the same entity, but this should work...
    	public virtual IList<Part> ParentParts {get; set;}
    	public virtual IList<Part> SubParts {get; set;}
    	
    	public Part()
    	{
    		AllCars = new List<Car>();
    		ParentParts = new List<Part>();
    		SubParts = new List<Part>();
    	}	
    }
