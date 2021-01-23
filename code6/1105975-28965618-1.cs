    string[] groupNames = windowsIdentity.Groups.Select(g=> g.Translate(typeof(NTAccount)).ToString()).ToArray();
    //Query the db for the role(s) associated with this groupname
    var query = from adGroup in AuthDbContext.ADGroups
                join adGroupRole in AuthDbContext.ADGroupRoles on adGroup.Id equals adGroupRole.ADGroupId
                where groupNames.Contains(adGroup.Name)
                select adGroupRole.Role.Name;
    //Add any found roles as claims to be added to the identity
    foreach (string Role in query)
    {
        claims.Add(new Claim(ClaimTypes.Role, Role));
    }
