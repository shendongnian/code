    ...
    var user = multipleResults.Read<User>().SingleOrDefault();
    
    var permissions= multipleResults.Read<Permissions>().ToList();
    if (user != null&& permissions != null)
    {
      user.Permissions.AddRange(permissions);
    }
    return user; // --> user type is User
    ...
