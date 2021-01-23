	public static Folder GetFolder(Web web, string fullFolderUrl)
	{
		if (string.IsNullOrEmpty(fullFolderUrl))
			throw new ArgumentNullException("fullFolderUrl");
		if (!web.IsPropertyAvailable("ServerRelativeUrl"))
		{
			web.Context.Load(web,w => w.ServerRelativeUrl);
			web.Context.ExecuteQuery();
		}
		var folder = web.GetFolderByServerRelativeUrl(web.ServerRelativeUrl + fullFolderUrl);
		web.Context.Load(folder);
		web.Context.ExecuteQuery();
		return folder;
	}
