	void Main()
	{
		string tableName = Console.ReadLine();
		
		Type.GetType("UserQuery").GetProperty(tableName)
								 .PropertyType
								 .GenericTypeArguments
								 .First()
								 .GetProperties()
								 .Dump("The properties of the " + tableName + " table");
	}
