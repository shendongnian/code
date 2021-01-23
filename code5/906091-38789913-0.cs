    public partial class Vehicle
    {
    	public string Name { get; set; }
    	public string Make { get; set; }
        ...
    }
        
    public partial class VEhicle
    {
    	public override bool Equals(object obj)
    	{
           ...
    	}
    }
