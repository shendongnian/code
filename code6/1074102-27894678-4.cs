    public virtual ActionResult Save(UserModel userModel)
    {
        if (userModel.UserType == UserType.Teacher)
            UpdateModel<TeacherModel>(userModel);
        else
            UpdateModel<StudentModel>(userModel);
        _userService.Save(userModel);
    }
