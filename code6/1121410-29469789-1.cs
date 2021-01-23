    private void TestNestedDynamicDictionary()
	{
		dynamic dictionary = new DynamicDictionary();
		dynamic nestedDictionary = new DynamicDictionary();
		nestedDictionary.Add("name", "Peter");
		dictionary.Add("person", nestedDictionary);
		var person = dictionary.person;
		var name = person.name;
		Console.WriteLine(name);
	}
