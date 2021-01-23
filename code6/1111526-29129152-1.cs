	public class Order<T> where T: OrderItem
	{
		public List<T> OrderItems { get; set; }
	}
	
	public class OrderItem
	{
	}
	
	public class SalesOrder : Order<SalesOrderItem>
	{
	}
	
	public class SalesOrderItem : OrderItem
	{
	}
