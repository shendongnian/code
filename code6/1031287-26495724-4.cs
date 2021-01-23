    public static void ShareListItem(ListItem listItem,Principal principal,string permissionLevelName)
    {
       var ctx = listItem.Context as ClientContext;
       var roleDefinition = ctx.Site.RootWeb.RoleDefinitions.GetByName(permissionLevelName);
       listItem.BreakRoleInheritance(true, false);
       var roleBindings = new RoleDefinitionBindingCollection(ctx) {roleDefinition};
       listItem.RoleAssignments.Add(principal, roleBindings);
       ctx.ExecuteQuery();
    }
