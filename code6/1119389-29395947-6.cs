    public class MyExpando : DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        //Want to create properties on initialization? Do it in the constructor
        public MyExpando()
        {
            dictionary.Add("PreferredName", "Darth Sidious");
            dictionary.Add("GreatDialog", "Something, something, darkside!");
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
			bool success = dictionary.TryGetValue(binder.Name, out result);
            if (success)
                result = ModifiedValue(result); 
            return success;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }
        private string ModifiedValue(object val)
        {
			//Modify your string here.
            if (val.ToString() != "Darth Sidious")
                return "Something something complete";
            return val.ToString();
        }
    }
