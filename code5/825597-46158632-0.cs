     RoleDefinitionCollection roleDefs = web.RoleDefinitions;
     var query = projectCtx.LoadQuery(roleDefs.Where(p => p.RoleTypeKind == RoleType.Contributor));
     projectCtx.ExecuteQuery();
     RoleDefinition roledefObj = query.FirstOrDefault();
     RoleDefinitionBindingCollection collRoleDefinitionBinding = new RoleDefinitionBindingCollection(projectCtx) { roledefObj };
     var roleAssignments = web.RoleAssignments;
     roleAssignments.Add(principalTest, collRoleDefinitionBinding);
     projectCtx.ExecuteQuery();
