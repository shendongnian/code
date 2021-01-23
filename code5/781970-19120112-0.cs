	public List<String> GetIDs(string domainName, string groupName)
	{
		using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName))
		using(GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, groupName))
			return (from x in grp.GetMembers(true).AsParallel() select x.SamAccountName).ToList();
	}
