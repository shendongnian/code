	public static void Write(Exception exception)
	{
		string logfile = String.Empty;
			try
		{
			logfile = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLog"]).ToString();
			if(File.Exists(logfile))
			{
				using(var writer = new StreamWriter(logfile, true))
				{
					writer.WriteLine(
						"=>{0} An Error occurred: {1}  Message: {2}{3}", 
						DateTime.Now, 
						exception.StackTrace, 
						exception.Message, 
						Environment.NewLine
						);
				}
			}
		}
		catch(Exception e)
		{
			throw;
		}
	}
