    var userToBeAdded1 = activeDirectoryClient.Context.Users
        .FirstOrDefaultAsync(user => user.ObjectId == "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
    var searchString = "Development";
    var foundGroup = activeDirectoryClient.Context.Groups
        .FirstOrDefaultAsync(group => group.DisplayName.StartsWith(searchString));
    if (foundGroup != null && foundGroup.ObjectId != null)
    {
        try
        {
            activeDirectoryClient.Context.AddLink(retrievedGroup, "members", userToBeAdded1);
            activeDirectoryClient.Context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError assigning member to group. {0} {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "");
        }
    }
