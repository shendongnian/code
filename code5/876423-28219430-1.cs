    public void ConnectoToDbWithEf6()
	{
	    using(var connection = CreateConnection(CreateConnectionString("server", "db", "you", "password")
		{
		    using(var context = new YourContext(connection, true))
			{
			    foreach(var someEntity in context.SomeEntitySet)
				{
				    Console.WriteLine(someEntity.ToString());
				}
			}
		}
	
	}
	
