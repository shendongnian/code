    ApplicationDbContext context = new ApplicationDbContext();
    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
    string ID = currentUser.Id;
    string Email = currentUser.Email;
    string Username = currentUser.UserName;
