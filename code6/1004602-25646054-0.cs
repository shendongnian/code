    foreach (System.Web.UI.WebControls.ListItem li in chkFriends.Items)
	{
		if (li.Selected == true)
		{
			strFriends += "'" + li.Value + "'" + ",";
			countFriends += 1;
		}
	}
