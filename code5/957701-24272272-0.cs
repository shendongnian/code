	using (var session = store.OpenSession())
	{
		dynamic entity = new ExpandoObject();
		entity.Id = "DynamicObjects/1";
		entity.Hello = "World";
		session.Store(entity);
		session.SaveChanges();
	}
	using (var session = store.OpenSession())
	{
		var json = session.Load<dynamic>("DynamicObjects/1") as IDynamicJsonObject;
		json.Inner["Name"] = "Lionel Ritchie";
		json.Inner["Hello"] = "Is it me you're looking for?";
		session.SaveChanges();
	}
	using (var session = store.OpenSession())
	{
		dynamic loadedAgain = session.Load<dynamic>("DynamicObjects/1");
		Console.WriteLine("{0} says Hello, {1}", loadedAgain.Name, loadedAgain.Hello);
		// -> Lionel Ritchie says Hello, Is it me you're looking for?"
	}
