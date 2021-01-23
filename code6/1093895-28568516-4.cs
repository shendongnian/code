    [HttpGet]
    [ClaimsPrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Resource = Resources.User, Operation = Operations.Edit)]
    public ActionResult ChangeUsername(Guid uniqueUserId)
    {
        User user = UserManager.GetUser(uniqueUserId);
        AuthorizationHelper.ConfirmAccess(Resources.User, Operations.Edit, user);
        var model = new VMMain(){UserGuid = user.Identifier,NewUsername = user.Username};
