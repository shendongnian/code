    public static bool HasRoles(this Controller controller, string action, string roles)
    {
        var controllerType = controller.GetType();
        var method = controllerType.GetMethod(action);
        var attrib = method.GetCustomAttributes(typeof(AuthorizeAttribute), true).FirstOrDefault() as AuthorizeAttribute;
        if (attrib == null)
        {
            throw new Exception();
        }
        return attrib.Roles == roles;
    }
