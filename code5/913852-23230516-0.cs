	private void Application_BeginRequest(object sender, EventArgs e)
	{
			MiniProfiler.Start();
	}
	private void Application_AuthenticateRequest(object sender, EventArgs e)
	{
         //stops the profiler if the user isn't on the tech team
		var currentUser = ClaimsPrincipal.Current.Identity as ClaimsIdentity;
		if (!Request.IsLocal && !currentUser.GetGlobalRoles().Contains(Constant.Roles.TechTeam))
		{
			MiniProfiler.Stop(discardResults:true);
		}
	}
	private void Application_EndRequest(object sender, EventArgs e)
	{
		MiniProfiler.Stop();
	}
