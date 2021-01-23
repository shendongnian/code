    public bool Edituser()
    {
        var user = 
            dbconnect.tblUsers.SingleOrDefault(u => u.userName == _VOUser.Username);
        if (user == null)
            // throw exception
        Mapper.Map(_VOUser, user);
        dbconnect.SubmitChanges();
        return true;
    }
