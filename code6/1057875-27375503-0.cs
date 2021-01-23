    public static IEnumerable<string[]> organizationType(User user)
    {
    	foreach (UserRoles ur in user.GetUserRoles())
    	{
    		OrganizationType ot = OrganizationType.Get(ur.organizationTypeId, "1");
    		string[] data = new string[] { ot.Name, ur.roleTypeId, ur.organizationId };
    		yield return data;
    	}
    }
