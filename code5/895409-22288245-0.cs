    public static void EditCurrentUser(int age)
    {
        var user = lstUser.FirstOrDefault(u => u.sFullName == "bob");
        if (user != null)
        {
            user.iAge = age
        }
    }
