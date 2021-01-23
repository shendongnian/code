    public class FrontEndMembershipProvider : MembershipProvider
    {
	public override bool ValidateUser(string username, string password)
	{
		var webSecurity = DependencyResolver.Current.GetService<IWebSecurity>();
		var cleanUsername = CleanUsername(this.Name, username);
		if (!string.IsNullOrEmpty(cleanUsername))
		{
			return webSecurity.ValidateUser(cleanUsername, password) != null;
		}
		return false;
	}
	public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
	{
		var usersRepository = DependencyResolver.Current.GetService<IUsersRepository>();
		var user = usersRepository.GetById((int)providerUserKey);
		if (user == null)
		{
			return null;
		}
		return this.CreateMembershipUser(user);
	}
	public override MembershipUser GetUser(string username, bool userIsOnline)
	{
		var usersRepository = DependencyResolver.Current.GetService<IUsersRepository>();
		var cleanUsername = CleanUsername(this.Name, username);
		if (!string.IsNullOrEmpty(cleanUsername))
		{
			var user = usersRepository.GetByEmail(cleanUsername);
			if (user != null)
			{
				return this.CreateMembershipUser(user);
			}
		}
		return null;
	}
	public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
	{
		var usersRepository = DependencyResolver.Current.GetService<IUsersRepository>();
		var membershipUserCollection = new MembershipUserCollection();
		var allUsersWithRole = usersRepository.GetAllUsersForSitecore(pageIndex + 1, pageSize);
		foreach (var user in allUsersWithRole)
		{
			membershipUserCollection.Add(this.CreateMembershipUser(user));
		}
		totalRecords = allUsersWithRole.TotalItemCount;
		return membershipUserCollection;
	}
	private MembershipUser CreateMembershipUser(User user)
	{
		return new MembershipUser(this.Name, UpgradeUsername(this.Name, user.Email), user.Id, user.Email, null, null, user.UserAccountStateId == (int)UserAccountStateType.Active, user.UserAccountStateId == (int)UserAccountStateType.Banned, user.CreationDate, user.LastActivityDate ?? user.CreationDate, user.LastActivityDate ?? user.CreationDate, user.CreationDate, user.CreationDate);
	}
	public static string CleanUsername(string domain, string username)
	{
		if (!string.IsNullOrEmpty(username))
		{
			if (username.Contains("\\"))
			{
				var parts = username.Split('\\');
				return parts[0] == domain ? parts[1] : null;
			}
		}
		return username;
	}
	public static string UpgradeUsername(string domain, string username)
	{
		if (!string.IsNullOrEmpty(username))
		{
			if (username.Contains("\\"))
			{
				var parts = username.Split('\\');
				if (parts[0] == domain)
				{
					return username;
				}
			}
			return domain + "\\" + username;
		}
		return username;
	}
}
