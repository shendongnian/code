    protected void Users_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "Delete")
    	{
    		int id = Convert.ToInt32(Users.DataKeys[e.RowIndex].Value);
    		ApplicationUser user = (ApplicationUser)IdentityManager.Store.Users.FindAsync(id, CancellationToken.None);
    		using (ApplicationDbContext dbcontext = new ApplicationDbContext())
    		{
    			dbcontext.UserLogins.RemoveRange(dbcontext.UserLogins.Where(ul => ul.UserId == user.Id));
    			dbcontext.UserRoles.RemoveRange(dbcontext.UserRoles.Where(ur => ur.UserId == user.Id));
    			dbcontext.UserSecrets.RemoveRange(dbcontext.UserSecrets.Where(us => us.UserName == user.UserName));
    			dbcontext.UserManagement.RemoveRange(dbcontext.UserManagement.Where(um => um.UserId == user.Id));
    			dbcontext.Users.Remove(dbcontext.Users.Where(usr => usr.Id == user.Id).Single());
    			dbcontext.SaveChanges();
    		}
    	}
    }
