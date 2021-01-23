		FacebookClient userFacebookClient = new FacebookClient(userAccessToken);
        var accountsResult = await userFacebookClient.GetTaskAsync<AccountsResult>("/me/accounts");
		string pageAccessToken = accountsResult.data.FirstOrDefault(account => account.id == PageId)?.access_token;
		if (pageAccessToken == null)
		{
			MessageBox.Show("Could not find page under user accounts.");
		}
		else
		{
			FacebookClient pageFacebookClient = new FacebookClient(pageAccessToken);
            // Use pageFacebookClient here
		}
