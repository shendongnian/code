    public virtual ActionResult Save(UserModel userModel)
    {
        if (userModel.UserType == UserType.Teacher)
            userModel = UpdateModel<TeacherModel>(userModel);
        else
            userModel = UpdateModel<StudentModel>(userModel);
        _userService.Save(userModel);
    }
