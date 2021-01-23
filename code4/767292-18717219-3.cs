    public class Item
    {
        public int Id { get; set; }
        public IList<Item> Items { get; set; }
    }
    var item = new Item {Id = 1, Items = new List<Item> 
    	{ 
    		new Item {Id = 2,  Items = new List<Item> {new Item { Id = 4, Items = new List<Item>()}}},
    		new Item {Id = 3,  Items = new List<Item>()},
    	}};
