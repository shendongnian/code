    Assert.IsTrue(_context.Object.ChangeTracker.Entries().Any(entry =>
				entry.Property("UserName").IsModified == false &&
				entry.Entity is IdentityUser &&
				(entry.Entity as IdentityUser).Id == users[0].Id // Here you can check if it is actually the same user
			));
