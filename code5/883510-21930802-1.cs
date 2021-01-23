    public bool Edituser()
    {
        var user = 
            dbconnect.tblUsers.SingleOrDefault(u => u.userName == _VOUser.Username);
        if (user == null)
            // throw exception
        user.password = _VOUser.Password;
        user.email = _VOUser.Email;
        user.mobile = _VOUser.Mobile;
        user.dateOfRegister = _VOUser.DateOfRegister;
        user.name = _VOUser.Name;
        user.family = _VOUser.Family;
        dbconnect.SubmitChanges();
        return true;
    }
