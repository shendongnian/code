	var roles1 = RoleModels.Master | RoleModels.Member;
	List<String> rolesStrings = new List<String> { "mAster", "Member", "editor" };
	
	var roles2 = rolesStrings.Select(x=>(RoleModels)Enum.Parse(typeof(RoleModels),x, true)).Aggregate((a, b) => a | b);
	
	if ((roles1&roles2)==roles2)
	{
		Console.WriteLine(String.Format("{0} (roles2) are in {1} (roles1)", roles2, roles1));
	}
	else
	{
		Console.WriteLine(String.Format("{0} (roles2) are not in {1} (roles1)", roles2, roles1));
	}
