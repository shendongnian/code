	public class Item
	{
		public double Val {get;set;}
	}
	public class Program
	{
		public void Main()
	    {
			var items = new List<Item>();
			items.Add(new Item(){Val=1.1});
			items.Add(new Item(){Val=2.1});
			items.Add(new Item(){Val=3.1});
			
			var variance = items.Variance<Item>((i) => i.Val);
			Console.WriteLine(variance);
	    }
	}
