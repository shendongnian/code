    // Load the user from the database
    User user = await UserDataContext.Users.SingleOrDefaultAsync(u => u.Id == "UserID");
    // Then load in all the venues
    await UserDataContext.Entry(user).Collection(u => u.Venues).LoadAsync();
    // Now you could access the venues
    foreach (var venue in user.Venues) Console.WriteLine(venue);
