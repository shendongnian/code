    public static bool IsValidLogin(string id, string password)
    {
           Student student = (from u in db.Students
                                       where u.Id.Equals(id) &&
                                       u.Password.Equals(CreatePasswordHash(password))
                                       select u);
                if(student != null)
                {
                    return true;
                }
                return false;
    }
