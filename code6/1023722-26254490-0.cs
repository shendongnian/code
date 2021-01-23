    var userService = ApplicationContext.Current.Services.UserService;
    var newUserModel = userService.GetUserById(userId);
    if (newUserModel != null)
    {
        newUserModel.IsLockedOut = false;
        userService.Save(newUserModel, false);
    }
