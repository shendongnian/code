	class UserMapping : ClassMapping<User>
	{
		public UserMapping() 
		{
			Id(x => x.ID, m => {
				m.Generator(Generators.Identity);
			});
			
            OneToOne(x => x.Avatar, m =>
            {
                m.Cascade(Cascade.All);
                m.Constrained(false);
            });			
		}
	}
	class UserAvatarMapping : ClassMapping<UserAvatar>
	{
		public UserAvatar() 
		{
			Id(x => x.UserID, m =>
			{
				m.Generator(Generators.Foreign<UserAvatar>(u => u.User));
			});
			
            OneToOne(x => x.User, m =>
            {
                m.Constrained(true);
            });			
			Property(x => x.Width);
			Property(x => x.Height);
		}
	}
