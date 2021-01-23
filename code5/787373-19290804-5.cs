		// GET api/users
        public PublicVisibleUsersList Getusers()
		{
			PublicVisibleUsersList myList = new PublicVisibleUsersList();
			var results = dbContext.Users.Where...//Entity Framework Linq query to fill data from database
            myList.AddRange(results); //AddRange() accepts an IEnumerable<T>, so I'm able to "convert" my results from the linq query to my newly defined list type by adding the result values to myList			
			return myList;
		}
