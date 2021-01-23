	if (HttpContext != null && HttpContext.User.Identity.IsAuthenticated)
	{
		MembershipUser mu = Membership.GetUser(HttpContext.User.Identity.Name);
		return context.Users.Where(u => u.UserKey == (Guid)mu.ProviderUserKey).FirstOrDefault();
	}
