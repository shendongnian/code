    public class MyRoleProvider : RoleProvider
	{
		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			// your logic here
		}
        public override bool IsUserInRole(string username, string roleName)
		{
			// your logic here
		}
        public override string[] GetAllRoles()
		{
			// your logic here
        }
        public override bool RoleExists(string roleName)
		{
			// your logic here
		}
        // etc...
     }
