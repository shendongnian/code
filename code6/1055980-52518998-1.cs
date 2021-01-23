     using (var dbContext = container.Resolve<ApplicationDbContext>())
    {
      dbContext.Database.Delete();
      dbContext.SaveChanges();
    }
