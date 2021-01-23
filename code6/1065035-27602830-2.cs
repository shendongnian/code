    public static bool? CanView(this ApplicationUser user, Project project)
    {
         var userRight = project.Rights.FirstOrDefault(r => r.User == user);
         return userRight == null ? (bool?)null : userRight.Right.HasFlag(AccessRight.View);
    }
