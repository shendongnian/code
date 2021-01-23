    public static void f3(DB.Group group, string name)
    {
        DB.DataContext dc = new DB.DataContext();
        dc.Groups.Attach(group);
        DB.User user = new DB.User() { Name = name, Group = group, };
        dc.Users.InsertOnSubmit(user);
        dc.SubmitChanges();
    }
