    DataLoadOptions options = new DataLoadOptions();
    if(includeEmail)
        options.LoadWith<User>(u => u.UserEmail);
    m_context.LoadOptions = options;
    var userData = m_context.Users.Where(u => u.Id == 1)
                                  .ToList();
    foreach(var user in userData)
    {
        // If includeEmail == true, then this will not trigger another db call
        // If includeEmail == false, then the UserEmail property will be lazily
        // loaded and another db call will be made for every iteration of this
        // loop (very bad).
        Console.WriteLine(user.UserEmail.Address);
    }
