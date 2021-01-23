    var user = model.UserName.Split('\\');
    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, user[0]))
    {
    	if (pc.ValidateCredentials(user[1], model.Password, ContextOptions.Negotiate))
    	{
    		using (var adUser = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, user[1]))
    		{
    			if (!MembershipService.ValidateUser(model.UserName, model.Password))
    			{
    				using (var _userDb = new UsersDbContext())
    				{
    					if (_userDb.aspnet_Users.Count(u => u.UserName.ToLower().Contains(model.UserName)) <= 0)
    					{
    						MembershipService.CreateUser(model.UserName, model.Password, adUser.EmailAddress);
    					}
    					else
    					{
    						var msUser = Membership.GetUser(model.UserName);
    						msUser.ChangePassword(msUser.ResetPassword(), model.Password);
    					}
    				}
    			}
    			FormsService.SignIn(model.UserName, model.RememberMe);
    
    			foreach (var role in Roles.GetAllRoles())
    			{
    				if (role == LoginRoles.Customer)
    					continue;
    
    				using (var group = GroupPrincipal.FindByIdentity(pc, role))
    				{
    					if (group != null)
    					{
    						if (adUser.IsMemberOf(group))
    						{
    							if (!Roles.IsUserInRole(model.UserName, role))
    								Roles.AddUserToRole(model.UserName, role);
    						}
    						else
    						{
    							if (Roles.IsUserInRole(model.UserName, role))
    								Roles.RemoveUserFromRole(model.UserName, role);
    						}
    					}
    				}
    			}
    		}
    	}
    }
