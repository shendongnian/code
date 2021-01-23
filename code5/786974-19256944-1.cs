    public static void CopyWebRoleAssignments(SPWeb sourceWeb, SPWeb destinationWeb)
    {
        //Copy Role Assignments from source to destination web.
        foreach (SPRoleAssignment sourceRoleAsg in sourceWeb.RoleAssignments)
        {
            SPRoleAssignment destinationRoleAsg = null;
            //Get the source member object
            SPPrincipal member = sourceRoleAsg.Member;
            //Check if the member is a user 
            try
            {
                SPUser sourceUser = (SPUser)member;
                destinationWeb.EnsureUser(sourceUser.LoginName);//EDITED
                SPUser destinationUser = destinationWeb.AllUsers[sourceUser.LoginName];
                if (destinationUser != null)
                {
                    destinationRoleAsg = new SPRoleAssignment(destinationUser);
                }
            }
            catch
            { }
            if (destinationRoleAsg == null)
            {
                //Check if the member is a group
                try
                {
                    SPGroup sourceGroup = (SPGroup)member;
                    SPGroup destinationGroup = destinationWeb.SiteGroups[sourceGroup.Name];
                    destinationRoleAsg = new SPRoleAssignment(destinationGroup);
                }
                catch
                { }
            }
            //At this state we should have the role assignment established either by user or group
            if (destinationRoleAsg != null)
            {
                foreach (SPRoleDefinition sourceRoleDefinition in sourceRoleAsg.RoleDefinitionBindings)
                {
                    try { destinationRoleAsg.RoleDefinitionBindings.Add(destinationWeb.RoleDefinitions[sourceRoleDefinition.Name]); }
                    catch { }
                }
                if (destinationRoleAsg.RoleDefinitionBindings.Count > 0)
                {
                    //handle additon of an existing  permission assignment error
                    try { destinationWeb.RoleAssignments.Add(destinationRoleAsg); }
                    catch (ArgumentException) { }
                }
            }
        }
        //Finally update the destination web
        destinationWeb.Update();
    }
