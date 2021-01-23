    public static void Main()
	{
		var list = FindProductsByName("green shirt", 2);
		foreach (var products in list)
			Console.WriteLine(products.ProductName);
	}
	public static IEnumerable<Products> FindProductsByName(string query, int limit)
	{
		string[] words = query.ToLower().Split(' ');
		List<Products> products = new List<Products>
		{
			new Products { ProductName = "green t-shirt large" },
			new Products { ProductName = "t-shirt green medium" },
			new Products { ProductName = "t-shirt red" }
		};
		return
			(from p in products
			let productsComponent = p.ProductName.Split(' ') // you should make a list of keyword in Products instead
			where productsComponent.Intersect(words).Any()
			select p).Take(limit);
	}
	public class Products
	{
		public string ProductName { get; set; }
	}
