    @if (Request.IsAuthenticated)
    {
      var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
      var currentUser = manager.FindById(User.Identity.GetUserId());
      var fullName = currentUser.Name + " " + currentUser.LastName;
      @fullName;
    }
    else
    {
      <span>Guess</span>
    }
