    void Main()
    {
    	Create<Customer>().Dump();
    }
    
    // Define other methods and classes here
    
    public class Name
    {
       public string Firstname { get; set; }
       public string Lastname { get; set; }
    }
    
    public class Address
    {
       public string City { get; set; }
       public string State { get; set; }
       public string Street { get; set; }
       public string Zip { get; set; }
    }
    
    public class Customer
    {
       public Name CustomerName { get; set; }
       public Address CustomerAddress { get; set; }
       public Guid Id { get; set; }
    }
    
    public static T Create<T>()
    {
    	var type = typeof(T);
    	
    	return (T)Create(type);
    }
    
    public static object Create(Type type)
    {
    	var obj = Activator.CreateInstance(type);
    	
    	foreach(var property in type.GetProperties())
    	{
    		var propertyType = property.PropertyType;
    		
    		if (propertyType.IsClass 
    			&& string.IsNullOrEmpty(propertyType.Namespace)
    			|| (!propertyType.Namespace.Equals("System") 
    				&& !propertyType.Namespace.StartsWith("System.")))
    		{
    			var child = Create(propertyType);
    			
    			property.SetValue(obj, child);
    		}
    	}
    	
    	return obj;
    }
