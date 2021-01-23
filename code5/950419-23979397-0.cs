    public class Object1DTO 
    {
    	public int Property {get; set;}
    }
    
    public class Object1 
    {
    	public int Property {get; set;}
    	
    	public static implicit operator Object1DTO(Object1 d)
        {
    		return new Object1DTO { Property = d.Property };
        }
    }
