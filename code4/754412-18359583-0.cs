        public static List<string> GetGroups(string userName)
        {
            RoleProvider roleProvider = new WindowsTokenRoleProvider();
            return roleProvider.GetRolesForUser(userName).ToList();
        }
