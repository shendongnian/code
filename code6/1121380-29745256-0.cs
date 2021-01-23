    ActiveDirectoryClient client = AuthenticationHelper.GetActiveDirectoryClient();
    user = (User) await client.Users.GetByObjectId(objectId).ExecuteAsync();
    
    var roleId = "";
    await user.AppRoleAssignments.Where(t=>t.ObjectId==roleId).FirstOrDefault().DeleteAsync();
