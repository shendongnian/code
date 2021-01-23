    var context =  new System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain);
    GroupPrincipal group = new GroupPrincipal(context,
        farm.Properties[GlobalNavigationConstants.Keys.GlobalNavigationOneDriveADGroup].ToString());
    	
    UserPrincipal usr = UserPrincipal.FindByIdentity(context, 
                                               IdentityType.Sid, 
                                               SPContext.Current.Web.CurrentUser.Sid);	
    
    var found = usr.IsMemberOf(group);
