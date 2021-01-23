	protected int UserId {
		get {
			return Convert.ToInt32(base.User.Identity.GetUserId());
		}
	}
