    command = new CommandDocument
	{
		{"createUser", "myUser"},
		{"pwd", "myPassword"},
		{"roles", new BsonArray 
			{
				new BsonDocument
				{
					{"role", "readWrite"},
					{"db", "myDatabaseName"}
				}
			}
        }
	};
