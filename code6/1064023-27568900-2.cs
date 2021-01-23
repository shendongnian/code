    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EnableLowerCamelCase();
        builder.EntitySet<Menu>("Menus");
        builder.EntitySet<MenuPermission>("MenuPermissions");
        var edmModel = builder.GetEdmModel();
        AddNavigations(edmModel); //see below for this method
        return edmModel;
    }
