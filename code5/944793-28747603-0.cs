	using Microsoft.AnalysisServices;
	using Microsoft.AnalysisServices.SPClient;
	using Microsoft.AnalysisServices.SPClient.Interfaces;
	
	string workbookUrl = "http://sharepoint/Shared%20Documents/spbook.xlsx";
	using (IWorkbookSession workbookSession = ASSPClientProxy.OpenWorkbookModel(workbookUrl))
	{
		bool hasEmbeddedModel = (workbookSession.Database != null);
		if (hasEmbeddedModel && workbookSession.WorkbookFormatVersion == WorkbookFileFormat.Excel2013)
		{
			using (Server server2 = new Server())
			{
				server2.Connect("Data Source=" + workbookSession.Server);
				Database database = server2.Databases.FindByName(workbookSession.Database);
				foreach (DataSource dataSource in database.DataSources)
				{
					dataSource.ConnectionString = dataSource.ConnectionString.Replace("parameter1", "parameter2");
					dataSource.Update();
				}
			}
		
			workbookSession.RefreshEmbeddedModel();
			workbookSession.Save();
		}
	}
