    private bool AdminIsValid(string username, string password)
    {
        using (var db = new AdminEntities())
        {
           return db.users.Any(u => u.password.Trim() == password &&
                                    u.uname.Trim() == username);
        }
    }
