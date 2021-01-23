	[EnableQuery]
	public IQueryable<User> GetUsers()
	{
        //Leave password empty
		Mapper.CreateMap<User, User>().					
			ForSourceMember(u => u.Password, opt => opt.Ignore());
        return db.Users.ToList().Select(u=>Mapper.Map<User>(u)).AsQueryable();		
	}
