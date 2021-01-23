	SqlCeConnection connection;
	if (System.Diagnostics.Debugger.IsAttached)
	{
		SqlCeConnection connection = new SqlCeConnection(@"Data Source=C:\Users\user\Documents\Visual Studio 2012\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Database1.sdf");
	}
	else
	{
		connection = new SqlCeConnection(@"Data Source=|DataDirectory|\Database1.sdf");
	}
