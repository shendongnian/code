    var users = SearchProducts().ToList();
    if ((users == null) || (users.Count() == 0))
    {
        ctx.StatusCode = System.Net.HttpStatusCode.NotFound;
        ctx.SuppressEntityBody = true;
    }
    else
    {
        usersList = new List<UserProfile>();
        foreach(User us in users)
        {
            usersList.Add(UserProfile.CreateUserView(us, userId));
        }
        ctx.StatusCode = System.Net.HttpStatusCode.OK;
    }
