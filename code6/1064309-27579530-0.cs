    class Program{
       static void Main(string[] args)
		{
			dynamic x = new GenericModel();
			x.First = "Robert";
			x.Last = " Pasta";
			Console.Write(x.First + x.Last);
		}
      }
    class GenericModel : DynamicObject
	{
		Dictionary<string, object> _collection = new Dictionary<string, object>();
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			return _collection.TryGetValue(binder.Name, out result);
		}
		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			_collection.Add(binder.Name, value);
			return true;
		}
	}
