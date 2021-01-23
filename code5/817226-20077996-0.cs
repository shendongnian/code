    public override bool ValidateUser(string username, string password, int companyId)
    {
		// DEV NOTE: change your GetUserId() return to int?
		int? userId = GetUserId(username, companyId);
		if (userID.HasValue())
			return WebSecurity.Login(username, password);
		else
			return false;
    }
