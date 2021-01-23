    private static bool DoesUserHasPermission(ClientContext context, List list, PermissionKind permissionKind)
            {
                context.Load(list, t => t.EffectiveBasePermissions);
                context.ExecuteQuery();
                return list.EffectiveBasePermissions.Has(permissionKind);
            }
