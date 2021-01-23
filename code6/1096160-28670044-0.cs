    SPWeb root = site.RootWeb;
    SPGroup group = root.SiteGroups[groupName];
                           
    SPRoleDefinition contributeRoleDef = root.RoleDefinitions.GetByType(SPRoleType.Contributor);
    SPRoleDefinition readerRoleDef = root.RoleDefinitions.GetByType(SPRoleType.Reader);
    SPRoleAssignment groupRoleAssignments = root.RoleAssignments.GetAssignmentByPrincipal(group);
    groupRoleAssignments.RoleDefinitionBindings.Remove(contributeRoleDef);
    groupRoleAssignments.RoleDefinitionBindings.Add(readerRoleDef);
    groupRoleAssignments.Update();
