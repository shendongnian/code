	public class ProductArgs
	{
		public int? ProductID { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public bool? MakeFlag { get; set; }
	}
	public List GET_Product(ProductArgs p){ ... }
