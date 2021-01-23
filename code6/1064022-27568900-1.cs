    private static void AddNavigations(IEdmModel edmModel)
    {
        AddMenuPermissionsNavigation(edmModel);
    }
    private static void AddMenuPermissionsNavigation(IEdmModel edmModel)
    {
        var menus = (EdmEntitySet) edmModel.EntityContainer.FindEntitySet("Menus");
        var menuPermissions = (EdmEntitySet)edmModel.EntityContainer.FindEntitySet("MenuPermissions");
        var menuType = (EdmEntityType) edmModel.FindDeclaredType("iiid8.cms.data.models.Menu");
        var menuPermissionType = (EdmEntityType)edmModel.FindDeclaredType("iiid8.cms.data.models.MenuPermission");
        AddOneToManyNavigation("MenuPermissions", menus, menuPermissions, menuType, menuPermissionType);
        AddManyToOneNavigation("Menu", menus, menuPermissions, menuType, menuPermissionType);
    }
    private static void AddOneToManyNavigation(string navTargetName, EdmEntitySet oneEntitySet, EdmEntitySet manyEntitySet,
        EdmEntityType oneEntityType, EdmEntityType manyEntityType)
    {
        var navPropertyInfo = new EdmNavigationPropertyInfo
        {
            TargetMultiplicity = EdmMultiplicity.Many,
            Target = manyEntityType,
            ContainsTarget = false,
            OnDelete = EdmOnDeleteAction.None,
            Name = navTargetName
        };
        oneEntitySet.AddNavigationTarget(oneEntityType.AddUnidirectionalNavigation(navPropertyInfo), manyEntitySet);
    }
    private static void AddManyToOneNavigation(string navTargetName, EdmEntitySet oneEntitySet, EdmEntitySet manyEntitySet,
        EdmEntityType oneEntityType, EdmEntityType manyEntityType) {
        var navPropertyInfo = new EdmNavigationPropertyInfo {
            TargetMultiplicity = EdmMultiplicity.One,
            Target = oneEntityType,
            ContainsTarget = false,
            OnDelete = EdmOnDeleteAction.None,
            Name = navTargetName
        };
        manyEntitySet.AddNavigationTarget(manyEntityType.AddUnidirectionalNavigation(navPropertyInfo), oneEntitySet);
    }
