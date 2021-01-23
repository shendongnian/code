    public virtual ActionResult Save(UserModel userModel)
    {
        // lookup user in database and verify the type of user they are
        var user = UserManager.GetUser(userModel.UserId)
        if (user.Role == "Teacher")
            userModel = UpdateModel<TeacherModel>(userModel);
        else
            userModel = UpdateModel<StudentModel>(userModel);
        _userService.Save(userModel);
    }
