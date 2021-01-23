	public sealed class Order
	{
		public Order()
		{
			Items = new MyCollection();
		}
		public MyCollection Items { get; private set; }
	}
	public sealed class OrderItem
	{
	}
	public class MyCollection : IEnumerable
	{
		private readonly List<OrderItem> _items = new List<OrderItem>();
		public void Add(OrderItem item)
		{
			_items.Add(item);
		}
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
