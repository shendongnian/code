    public class JsonType()
    {
    	public CustomerType Customer {get; set;}
    	public FruitType Fruit {get; set;}
    	public LengthType Length {get; set;}
    }
    
    public class CustomerType()
    {
    	public string firstName {get; set;}
    	public string lastName {get; set;}
    	public string Type {get; set;}
    }
    
    public class FruitType()
    {
    	public string fruit {get; set;}
    	public string Type {get; set;}
    }
