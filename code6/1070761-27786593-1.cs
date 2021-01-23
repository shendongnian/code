       var ListOfUsers = MyMethodThatRetunsAllOldMembers();
       foreach member in ListOfUsers{
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
        var user = new ApplicationUser() { UserName = Member.UserName, Email = Member.Email };
        IdentityResult result = manager.Create(member.LoginName, Member.Password);
        //Example: You can even add roles at the same time.
        var ra = new RoleActions();
        ra.AddUserToRoll(member.LoginName, Member.Email, userRole);
        }
