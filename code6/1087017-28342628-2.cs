    public class Wrapper<T> where T : Base
	{
		public List<T> Children { get; set; }
	}
    public class Base 
	{ 
		public string Name { get; set; }
	}
	public class Item : Base
	{
		public Guid GroupId { get; set; }
	}
	public class Group : Base 
	{
		public Guid ID { get; set; }
		public List<Item> GroupItems { get; private set; }
	}
