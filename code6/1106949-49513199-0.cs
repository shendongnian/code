    public static class RoleManagerExtensions
    {
    	public static List<CheckBoxItem> GetRolesSelectList(
    		this RoleManager<ApplicationRole> roleManager,
    		IList<string> selectedValues)
    	{
    		List<CheckBoxItem> roles = 
    			roleManager.Roles.ToList().Select(r => new CheckBoxItem
    		{
    			Selected = selectedValues.Contains(r.Name),
    			Id = r.Name,
    			Name = r.Name
    		}).ToList();
    		return roles;
    	}
    }
