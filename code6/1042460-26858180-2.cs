    void Main()
    {
    	var genericDictionaryType = typeof(Dictionary<,>);
    	var method = genericDictionaryType.GetMethod("ContainsKey");
    	var dict = new Dictionary<string, string>();
    
    	dict.Add("foo", "bar");
    	Console.WriteLine("{0}", method.Invoke(dict, new[] { "foo" }));
    }
