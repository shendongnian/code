	var allUsers = Membership.GetAllUsers();
	if (allUsers.Count > 0)
	{
		actionResults.InnerHtml += allUsers.Count + "<br />";
		try
		{
			var count = 0;
			foreach (var user in allUsers)
			{
				actionResults.InnerHtml += user.ToString() + "<br />";
				count++;
				if (count > 50)
				{
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
		}
	}
