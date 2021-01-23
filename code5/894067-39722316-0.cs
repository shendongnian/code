    public enum MyEnum
	{
		Car,
		Bicycle,
		Boat
	}
	[Serializable()]
	public class MyClass
	{
		private string _id;
		private MyEnum? _myEnum;
		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}
		public MyEnum? EnumValue
		{
			get { return _myEnum; }
			set { _myEnum = value; }
		}
		public MyClass(string id)
		{
			this._id = id;
		}
		public MyClass() : this("")
		{
		}
	}
