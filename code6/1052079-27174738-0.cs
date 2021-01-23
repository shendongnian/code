    void Main()
    {
    	Func<Item, bool> expression = x => x.ValueType == 2 && Convert.ToDouble(x.Value) > 5;
    	var list = new List<Item>();
    	list.Add(new Item { ValueType = 1, Value = "abc" });
    	list.Add(new Item { ValueType = 1, Value = "def" });
    	list.Add(new Item { ValueType = 2, Value = "25" });
    	list.Add(new Item { ValueType = 2, Value = "37" });
    	var results = list.AsQueryable().Where(expression);
    	
    	results.Dump();
    }
    
    public class Item
    {
    	public int ValueType {get;set;}
    	public string Value {get;set;}
    }
