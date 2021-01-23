    private async Task DeleteUser()
    {
        ActiveDirectoryClient client = AuthenticationHelper.GetActiveDirectoryClient();
        // Retrieve user from its displayname
        var user = await client.Users.Where(u => u.DisplayName == "user two").ExecuteSingleAsync();
        // Or Retrieve user from its principal name
        // var user = await client.Users.Where(u => u.UserPrincipalName== "user two").ExecuteSingleAsync();
        // Or Retrieve user from its id in the directory
        //var user = await client.Users.GetByObjectId("0b34c995-0970-4776-ae87-f66d384f9c45").ExecuteAsync();
        // Delete the user
        await user.DeleteAsync();
    }
