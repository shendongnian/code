	[EnableQuery]
	public IQueryable<User> GetUsers()
	{
        //Leave password empty
		Mapper.CreateMap<User, User>().					
			ForMember(e => e.Password, opt => opt.UseDestinationValue());
			
		var list = new List<User>();
        return db.Users.Select(u=>Mapper.Map<User>(u)).AsQueryable();		
	}
