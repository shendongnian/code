    UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));         
    var user = UserManager.FindById(User.Identity.GetUserId());
    if (user != null)
        _appointmentRepository.SendEmailToOwner(user.Email, appointmentId);
 
