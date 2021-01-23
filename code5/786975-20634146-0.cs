    public static void CopyWebRoleAssignmentsFrom(this SPWeb web, SPWeb fromWeb)
    {
    	web.BreakRoleInheritance(false);
    	foreach (SPRoleAssignment sourceRoleAsg in fromWeb.RoleAssignments)
    	{
    		SPRoleAssignment destinationRoleAsg = null;
    		SPPrincipal member = sourceRoleAsg.Member;
    		if (member is SPUser)
    		{
    			SPUser sourceUser = member as SPUser;
    			SPUser user = web.SiteUsers[sourceUser.LoginName];
    			destinationRoleAsg = new SPRoleAssignment(user);
    		}
    		else if (member is SPGroup)
    		{
    			SPGroup sourceGroup = (SPGroup)member;
    			SPGroup group = web.SiteGroups[sourceGroup.Name];
    			destinationRoleAsg = new SPRoleAssignment(group);
    		}
    
    		foreach (SPRoleDefinition sourceRoleDefinition in sourceRoleAsg.RoleDefinitionBindings)
    		{
    			destinationRoleAsg.RoleDefinitionBindings.Add(web.RoleDefinitions[sourceRoleDefinition.Name]);
    		}
    
    		if (destinationRoleAsg.RoleDefinitionBindings.Count > 0)
    		{
    			web.RoleAssignments.Add(destinationRoleAsg);
    		}
    	}
    	web.Update();
    }
