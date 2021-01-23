	public static class RoleHelper
	{
		private static async Task EnsureRoleCreated(RoleManager<IdentityRole> roleManager, string roleName)
		{
			if (!await roleManager.RoleExistsAsync(roleName))
			{
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}
		}
		public static async Task EnsureRolesCreated(this RoleManager<IdentityRole> roleManager)
		{
			// add all roles, that should be in database, here
			await EnsureRoleCreated(roleManager, "Developer");
		}
	}
    public async void Configure(..., RoleManager<IdentityRole> roleManager, ...)
    {
         ...
         await roleManager.EnsureRolesCreated();
         ...
    }
