    public void UnlinkUsersFromRoles(int[] roleIds, int[] userIds)
    {
        using (var context = new DefaultContext())
        {
            foreach (var ur in context.UserRoles
                                      .Where(u => userIds.Contains(u.UserId))
                                      .Where(r => roleIds.Contains(r.RoleId))
                                      .ToArray())
            {
                context.UserRoles.Remove(ur);
            }
            context.SaveChanges();
        }
    }
