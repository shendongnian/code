    public class StringValue : Attribute
    {
    	public string Name { get; private set; }
    	public StringValue(string name)
    	{
    		this.Name = name;
    	}
    }
