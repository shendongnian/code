	public class SalesOrder
	{	
		public string Name { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		
		public SalesOrder(string Name, double Price, int Quantity)
		{
			this.Name = Name;
			this.Price = Price;
			this.Quantity = Quantity;
		}
	}
