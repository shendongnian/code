    public async Task<JsonResult> FindUser(string pre) {
	ActiveDirectoryClient client = AADHelper.GetActiveDirectoryClient();
           
	IPagedCollection<IUser> pagedCollection = await client.Users.Where(u => u.UserPrincipalName.StartsWith(pre, StringComparison.CurrentCultureIgnoreCase)).ExecuteAsync();
	if (pagedCollection != null)
	{
		do
		{
			List<IUser> usersList = pagedCollection.CurrentPage.ToList();
			foreach (IUser user in usersList)
			{
				userList.Add((User)user);
			}
			pagedCollection = await pagedCollection.GetNextPageAsync();
		} while (pagedCollection != null);
	}
	return Json(userList, JsonRequestBehavior.AllowGet);		
