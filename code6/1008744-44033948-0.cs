    Assert.IsTrue(dbContext.Object.ChangeTracker.Entries().Any(entry =>
				entry.State == EntityState.Modified &&
				entry.Entity is IdentityUser &&
				(entry.Entity as IdentityUser).Id == users[0].Id // Here you can check if it is actually the same user
			));
