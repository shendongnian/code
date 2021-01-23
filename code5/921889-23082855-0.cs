    public void DeleteUser(string userid, string siteid)
    {
        var user = db_context.PlayerInfoes.Where(x=>x.UserId.Equals(userid)
                                                 && x.SiteId.Equals(siteid);
        user.Active = false;
        db_context.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
        db_context.SaveChanges();
    }
