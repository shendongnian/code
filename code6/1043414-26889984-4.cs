    public class ItemModel
    {
    	private static int counter = 0;
    	public int Index { get; set; }
    	public string Name { get; set; }
    	public string Address { get; set; }
    	public DateTime Age { get; set; }
    
    	public ItemModel(string name, string address, DateTime? age = null)
    	{
    		Name = name;
    		Address = address;
    		Age = age ?? DateTime.Now;
    		Index = ++counter;
    	}
    }
