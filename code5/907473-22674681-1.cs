	Book[] books = new Book[] 
		{ 
			new Book { ID = 1, Name = "A B C" },
			new Book { ID = 2, Name = "Word Two" },
			new Book { ID = 3, Name = "Third Book" },
			new Book { ID = 4, Name = "And Another" },
			new Book { ID = 5, Name = "The Last Word" }
		};
	User[] users = new User[] 
		{ 
			new User { ID = 1, Name = "A" },
			new User { ID = 2, Name = "B" },
		};
	Rating[] ratings = new Rating[] 
		{
			new Rating { UserID = 1, BookID = 1, Value = 2 },
			new Rating { UserID = 1, BookID = 2, Value = 5 },
			new Rating { UserID = 1, BookID = 3, Value = 4 },
			new Rating { UserID = 1, BookID = 4, Value = 1 },
			//new Rating { UserID = 1, BookID = 5, Value = 1 },
			new Rating { UserID = 2, BookID = 1, Value = 5 },
			new Rating { UserID = 2, BookID = 2, Value = 5 },
			new Rating { UserID = 2, BookID = 3, Value = 0 },
			new Rating { UserID = 2, BookID = 4, Value = 1 },
			//new Rating { UserID = 2, BookID = 5, Value = 2 },
		};
