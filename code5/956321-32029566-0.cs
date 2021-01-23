	public ActionResult Logoff()
	{
		HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
		HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
		HttpContext.Response.Cache.SetNoStore();
		Session.Clear();
		Session.Abandon();
		Session.RemoveAll();
		FormsAuthentication.SignOut();
		return RedirectToAction("Index", "Home");
	}
