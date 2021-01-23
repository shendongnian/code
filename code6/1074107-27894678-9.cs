    public virtual ActionResult Save(UserModel userModel)
    {
        TeacherModel tmodel = null;
        StudentModel smodel = null;
        // lookup user in database and verify the type of user they are
        var user = UserManager.GetUser(userModel.UserId)
        if (user.Role == "Teacher")
            tmodel = new TeacherModel();
            UpdateModel<TeacherModel>(tmodel);
        }
        else {
            smodel = new StudentModel();
            UpdateModel<StudentModel>(smodel);
        }
        _userService.Save((UserModel)tmodel ?? smodel);
    }
