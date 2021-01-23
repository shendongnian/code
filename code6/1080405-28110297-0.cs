    public HttpUserService : ICurrentUserService
	{
		public int? GetUserId()
		{
			return User.Identity.GetUserId();
		}
	}
    
