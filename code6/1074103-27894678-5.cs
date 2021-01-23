    public virtual ActionResult Save(UserModel userModel)
    {
        // lookup user in database and verify the type of user they are
        var user = UserManager.GetUser(userModel.UserId)
        if (user.Role == "Teacher")
            UpdateModel<TeacherModel>(userModel);
        else
            UpdateModel<StudentModel>(userModel);
        _userService.Save(userModel);
    }
