    void Main()
    {
    	var list = new List<Item>()
    	{
    		new Item(){Id= 0, Name= "ItemA"},
    		new Item(){Id= 1, Name= "ItemB"},
    		new Item(){Id= 1, Name= "ItemC"},
    		new Item(){Id= 2, Name= "ItemD"},
    		new Item(){Id= 3, Name= "ItemE"},
    		new Item(){Id= 3, Name= "ItemF"},
    		new Item(){Id= 4, Name= "ItemG"},
    		new Item(){Id= 5, Name= "ItemH"}
    	};
    	
    	var set = new HashSet<int>();
    	var unique = new List<Item>();
    	var dupes = new List<Item>(); 
    	foreach (var item in list)
    	{
    		if(set.Add(item.Id))
    			unique.Add(item);
    		else
    			dupes.Add(item);
    	}
    }
    
    public class Item
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
