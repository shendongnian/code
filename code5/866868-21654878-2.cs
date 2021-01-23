	protected int UserId {
		get {
			return Convert.ToInt32(((ClaimsPrincipal)base.User).Identity.GetUserId());
		}
	}
