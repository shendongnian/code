	public class DynamicDictionary : DynamicObject
	{
		private readonly Dictionary<string, object> dictionary;
		public DynamicDictionary(Dictionary<string, object> dictionary)
		{
			this.dictionary = dictionary;
		}
		public override bool TryGetMember(
			GetMemberBinder binder, out object result)
		{
			return dictionary.TryGetValue(binder.Name, out result);
		}
		public override bool TrySetMember(
			SetMemberBinder binder, object value)
		{
			dictionary[binder.Name] = value;
			return true;
		}
	}
