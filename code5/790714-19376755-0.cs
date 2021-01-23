	System.Web.HttpContext context = System.Web.HttpContext.Current;
	int start, limit;
	if ( int.TryParse(context.Request["start"], out start) &&
		int.TryParse(context.Request["limit"], out limit) )
	{
		// send the data to client
	}
	else
	{
		// error handling
	}
