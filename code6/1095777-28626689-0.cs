	using (var context = new PushjobModel.PushjobEntities(GetConnectionString(CompanyName)))
	{
		var list = context.GetAllActivePushjobs();
		foreach (PushjobModel.Pushjob item in list)
		{
			item.IsActive = false;
			item.IsSent = true;
		}
		context.SaveChanges();
	}
	public static void GetConnectionString(string CompanyName)
	{
		string connectionstring = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[CompanyName].ConnectionString;
	}
