    void ListProperties(Type t)
    {
    	foreach (PropertyInfo p in t.GetProperties())
    	{
    		string propName = p.PropertyType.Name;
    		Console.WriteLine("Property {0} expects {1} {2}",
    			p.Name,
    			"aeiou".Contains(char.ToLower(propName[0])) ? "an" : "a",
    			propName);
   			ListProperties(p.PropertyType);
    	}
    }
    ListProperties(typeof(Blog));
