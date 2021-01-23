    public interface IOrder
    {
    	IEnumerable<OrderItem> GetItems();
    }
	public class Order<T> : IOrder where T: OrderItem
	{
		public List<T> OrderItems { get; set; }
		
		public IEnumerable<OrderItem> GetItems()
		{
			return this.OrderItems;
		}
	}
