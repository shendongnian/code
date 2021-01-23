    var listOfUser = new List<User>();
    foreach (var r in rows)
    {
        var user = new User();
        user.Id = r.Id;
        user.UserName = r.user_name;
        user.UserEmail = r.user_email;
        user.Status = r.status; 
        user.Role = r.Role;
        listOfUser.Add(user);
    }
    return listOfUser;
