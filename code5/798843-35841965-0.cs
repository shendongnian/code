	var serverManager = ServerManager.OpenRemote("ServerName");
	var sites = string.Join(";", serverManager.Sites.Select(o => o.ToString()));
	Console.WriteLine(sites);
	try
	{
		serverManager.Sites.Add("newWebSite", @"D:\TestSite", 80);
	}
	catch ( Exception e )
	{
		Console.WriteLine(e);
	}
	Console.WriteLine(string.Join(";", serverManager.Sites.Select(o => o.ToString())));
	Console.WriteLine(string.Join(";", ServerManager.OpenRemote("ServerName").Sites.Select(o => o.ToString())));
	serverManager.CommitChanges();
	Console.WriteLine(string.Join(";", ServerManager.OpenRemote("ServerName").Sites.Select(o => o.ToString())));
	Console.ReadLine();
