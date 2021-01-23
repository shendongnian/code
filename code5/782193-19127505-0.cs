    public bool ApproveUser(string username)  
    {
        using (var context = new UserRegistrationEntities())
        {
            // The entry object gets populated correctly
            var entry = context.PendingApprovals
                    .Where(e => e.Username.Equals(username))
                    .FirstOrDefault();
            try
            {
                context.PendingApprovals.Remove(entry);
                context.DeleteObject(entry);
                // Also tried context.PendingApprovals.DeleteObject(entry)
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
