    var users = UserDal.GetAllUsers();
    if (users == null || !users.Any())
    {
        // handle error
    }
    var user = users.First(x => x.Id == someId);
