	[EnableQuery]
	public IQueryable<User> GetUsers()
	{
        //Leave password empty
		Mapper.CreateMap<User, User>().					
			ForMember(e => e.Password, opt => opt.UseDestinationValue());
        return db.Users.Select(u=>Mapper.Map<User>(u)).AsQueryable();		
	}
