		// GET api/users
        public PublicVisibleUsersList Getusers()
		{
			PublicVisibleUsersList myList = new PublicVisibleUsersList();
			var results = dbContext.Users.Where...//Entity Framework Linq query to fill data from database
            myList.AddRange(results);			
			return myList;
		}
