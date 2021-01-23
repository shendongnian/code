    public class ListBoxPersonExample
	{
		public ListBoxPersonExample(string name)
		{
			Name = name;
		}
		public string Name { get; set; }
		public override string ToString()
		{
			return "My name is :" + Name;
		}
	}
    
