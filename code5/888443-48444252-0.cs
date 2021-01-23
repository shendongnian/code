	public static ActionResult FileBrowser(Session session)
	{
		try
		{
            // Call your file browser here.
            session[VALUE] = "New value";
			session.DoAction("Reset");
			return ActionResult.Success;
		}
		catch (Exception ex)
		{
			session.Log($"Unable to launch the file browser: {ex.Message}");
			return ActionResult.Failure;
		}
	}
