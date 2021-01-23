    SPWeb currentWeb = topSite.RootWeb;
    SPList testList = currentWeb.Lists["ListName"];
    SPUser currentUser = currentWeb.SiteUsers["domain\\userName"];
    SPRoleAssignment customRoleAssignment = new SPRoleAssignment(currentUser);
    SPRoleDefinition customRoleDefinition = currentWeb.RoleDefinitions["My Test Level"];
    customRoleAssignment.RoleDefinitionBindings.Add(customRoleDefinition);
    
    testList.BreakRoleInheritance(false);
    testList.RoleAssignments.Add(customRoleAssignment);
    testList.Update();
