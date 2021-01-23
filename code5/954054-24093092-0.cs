    public class Item
    {
    	public virtual void Execute() {}
    }
    
    public class Book : Item
    {
    	public override void Execute() { Console.WriteLine("I'm a book"); }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		List<Item> items = new List<Item> { new Item() , new Item() , new Book(), new Book() };
    		foreach(var item in items)
    		    item.Execute();
    	}
    }
