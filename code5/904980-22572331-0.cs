	public class MyObject
	{
		public string Key
		{
			get;
			set;
		}
		public int Foo
		{
			get;
			set;
		}
	}
	public class MyObjectCollection : KeyedCollection<string, MyObject>
	{
		protected override string GetKeyForItem(MyObject item)
		{
			return item.Key;
		}
	}
