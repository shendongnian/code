    public virtual ActionResult Save(UserModel userModel)
    {
        TeacherModel tmodel = null;
        StudentModel smodel = null;
        if (userModel.UserType == UserType.Teacher) {
            tmodel = new TeacherModel();
            UpdateModel<TeacherModel>(tmodel);
        }
        else {
            smodel = new StudentModel();
            UpdateModel<StudentModel>(smodel);
        }
        _userService.Save((UserModel)tmodel ?? smodel);
    }
