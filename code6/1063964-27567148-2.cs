    if (Manager.Users.Select(d => d).Where(d => d.UserName == UserName).ToList().Count() > 0)
    {
            // the Item is Exist in the list
    }
    else
    {
            Manager.Users.Add(new Users { UserName = Username, Pass= Password});
    }
