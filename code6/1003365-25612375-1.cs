	User GetUser(String name, String email) 
	{
		using (var tran = new TransactionScope())
		{
			using (var context = new DataContext()) 
			{
				User user = context.Users.FirstOrDefault(u => u.email.Equals(email));
				if (user != null)
					return user;
				user = new User() { name = name, email = email };
				context.Users.InsertOnSubmit(user);
				context.SubmitChanges();
				
				tran.Complete();
				
				return user;
			}
		}
	}
