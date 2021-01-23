    using (ApplicationDbContext dbCtx = new ApplicationDbContext())
    {
        // use the same context for the UserManager
        UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbCtx));
        // user to update
        var user = UserManager.Users
            .ToList()
            .First(u => u.Id == User.Identity.GetUserId());
        // movie to update
        var movie = dbCtx.Movies.SingleOrDefault(m => m.Name == "Star Wars");
        // this is the  only property i want to update
        movie.IsRented = true;
        dbCtx.SaveChanges();
        // user update
        user.IsRenting = true;
        user.MovieRented = movie;
        // this is should do the trick
        UserManager.Update(user);
    }
