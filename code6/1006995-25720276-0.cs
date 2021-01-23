    void Main()
    {
    	var custList = new List<Customer>()
    	{ 
    		new Customer(){ Country = new Country(){ Name = "Sweden" } },
    		new Customer(){ Country = new Country(){ Name = "Denmark" } },
    	};
    
    	var itemProp = typeof(Customer).GetProperty("Country");
    
    	custList = custList.OrderBy(cust => itemProp.GetValue(cust, null)).ToList();
    	
    	custList.Dump();
    }
    
    public class Country : IComparable<Country>, IComparable
    {
    	public string Name {get;set;}
    
    	public int CompareTo(Country other)
    	{
    		return string.Compare(this.Name, other.Name);
    	}
    	
    	public int CompareTo(object other)
    	{
    		var o = other as Country;
    		if(o == null)
    			return 0; //Or how you want to handle it
    		return CompareTo(o);
    	}
    }
    
    public class Customer
    {
    	public Country Country{get;set;}
    }
