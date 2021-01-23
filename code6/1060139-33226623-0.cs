    var graphClient = new ActiveDirectoryClient(new Uri(ConfigHelper.GraphServiceRoot), async () => await GetUserTokenAsync(cache));
    var actualUser = await graphClient.Users.GetByObjectId(matchedUser.ObjectId).ExecuteAsync();
    var actualGroup = (Group) await graphClient.Groups.GetByObjectId(matchedGroup.ObjectId).ExecuteAsync();
    
    actualGroup.Members.Add(actualUser as DirectoryObject);
    await graphClient.Context.SaveChangesAsync();
