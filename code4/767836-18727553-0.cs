    internal static string UsersInRoleTableName
    {
      get
      {
        return "webpages_UsersInRoles";
      }
    }
    List<object> list = Enumerable.ToList<object>(database.Query("SELECT u." + this.SafeUserNameColumn + " FROM " + this.SafeUserTableName + " u, " + SimpleRoleProvider.UsersInRoleTableName + " ur, " + SimpleRoleProvider.RoleTableName + " r Where (r.RoleName = @0 and ur.RoleId = r.RoleId and ur.UserId = u." + this.SafeUserIdColumn + " and u." + this.SafeUserNameColumn + " LIKE @1)", (object) roleName, (object) usernameToMatch));
        
