	string connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder
	{
		Metadata = "res://*/Models.ModelKDM.csdl|res://*/Models.ModelKDM.ssdl|res://*/Models.ModelKDM.msl",
		Provider = "Oracle.DataAccess.Client",
		ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
		{
			DataSource = server,
			UserID = user,
			Password = pass,
		}.ConnectionString
	}.ConnectionString;
	return connectionString;
