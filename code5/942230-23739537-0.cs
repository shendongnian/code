    void Main()
    {
        //dummy data
    	var items = new List<Item>()
    			    {
                        new Item{Id =1, Name = "Bangles", Price=100},
                        new Item{Id =2, Name = "Saree",   Price=200},
                        new Item{Id =3, Name = "Shoes",   Price=150},
                        new Item{Id =4, Name = "Bangles", Price=100},
                        new Item{Id =5, Name = "Shoes",   Price=150}
                     };
        //select duplicate items		 
    	var itemsToDelete = items.GroupBy (i => new { i.Name, i.Price}).SelectMany(x => x.Skip(1));
        //delete duplicate items
    	context.DeleteAllOnsubmit(itemsToDelete);
        //Save
    	context.SaveChanges();
    	
    }
    public class Item
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int Price { get; set; }
    }
