        // GET api/users
        public IEnumerable<PublicVisibleUserDTO> Getusers()
		{
			var results = dbContext.Users.Where...//Entity Framework Linq query to fill data from database
			return results;
		}
