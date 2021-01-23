	class Program
	{
		static void Main(string[] args)
		{
			Container<int> container = new Container<int>();
			container.AddItem(4);
			container.AddItem(11);
			container.AddItem(6);
			Console.WriteLine(container.GetMaximum());
		}
	}
	public class Container<T> where T : IComparable<T>
	{
		private  readonly List<T> _items = new List<T>();
		public void AddItem(T item)
		{
			_items.Add(item);
		}
		public T GetMaximum()
		{
			return _items.Max();
		}
	}
