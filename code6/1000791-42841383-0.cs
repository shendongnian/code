        public class MyDbInitializer : IDatabaseInitializer<MyDbContext>
	    {
		   public void InitializeDatabase(MyDbContext context)
		   {
			  if (context.Database.Exists())
			  {
				if (!context.Database.CompatibleWithModel(true))
				{
					context.Database.Delete();
				}
			  }
			  context.Database.Create();
			  User myUser = new User()
			  {
			  	Email = "a@b.com",
				Password = "secure-password"
			  };
			  context.Users.AddOrUpdate<User>(p => p.Email, myUser);
			  context.SaveChanges();
		   }
	    }
