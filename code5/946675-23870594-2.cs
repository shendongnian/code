	class Program
	{
		static void Main(string[] args)
		{
			Container<int> container = new Container<int>();
			container.AddItem(4);
			container.AddItem(11);
			container.AddItem(6);
			Console.WriteLine(container.GetMaximum());
			Container<Person> container2 = new Container<Person>();
			container2.AddItem(new Person() { Age = 36 });
			container2.AddItem(new Person() { Age = 47 });
			container2.AddItem(new Person() { Age = 48 });
			Console.WriteLine(container2.GetMaximum().Age);
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
	public class Person : IComparable<Person>
	{
		public int Age { get; set; }
		public int CompareTo(Person other)
		{
			return Age.CompareTo(other.Age);
		}
	}
