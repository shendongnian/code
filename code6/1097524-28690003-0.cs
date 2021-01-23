	var currentUser = Membership.GetUser(model.Email);
	if (currentUser != null)
	{
		if (currentUser.LastPasswordChangedDate == currentUser.CreationDate)
		{
            // User has not changed password since created.
			return RedirectPermanent("Login/?userName=" + model.Email);
		}
	}
