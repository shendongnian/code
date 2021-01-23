	[Authorize]
	public JsonResult GetMessagesForUser()
	{
		// get user ID
		Guid userId = YourIdentityProvider.User.Id;
		
		// check messages like this:
		var messages = from m in ctx.Messages
						where m.UserId == userId
						&& m.IsRead == false
						select m;
						
		return Json(messages.ToList(), JsonRequestBehavior.AllowGet);
	}
