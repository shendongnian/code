    public bool ApproveUser(string username)  
    {
        using (var context = new UserRegistrationEntities())
        {
            // The entry object gets populated correctly
            var entry = context.PendingApprovals
                    .First(e => e.Username.Equals(username))
            if (entry != null) {
            try
            {
                context.PendingApprovals.DeleteObject(entry);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            }
        }
        return false;
    }
