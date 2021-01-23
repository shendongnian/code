    public class MyExpando : DynamicObject
    {
        Dictionary<string, object> dictionary;
        public MyExpando()
        {
           dictionary = new Dictionary<string, object>
		   {
				{"Id", "1"},
				{"Title", "My title"},
				{"Description", "Blah blah blah"},
		   };
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
			return dictionary.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!dictionary.ContainsKey(binder.Name))
                return false;
            dictionary[binder.Name] = value;
            return true;
        }
    }
