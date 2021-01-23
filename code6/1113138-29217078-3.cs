    public ActionResult ProfileViewModel()
        {
            var userid = User.Identity.GetUserId();
            var mngr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var theuser = mngr.FindById(userid);
            profileViewModel profile = new profileViewModel();
            profile.FirstName = theuser.FirstName;
            profile.LastName = theuser.LastName;
            profile.HomeAddress = theuser.HomeAddress;
            return View(profile);
        }
