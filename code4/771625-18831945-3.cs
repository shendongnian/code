    private void button1_Click(object sender, EventArgs e)
    {
    	var root = "ftp://ftp.yourFTPServer.at";
    
    	treeView1.Nodes.Clear();
    	treeView1.Nodes.Add(CreateDirectoryNode(root, "root"));
    }
    
    private TreeNode CreateDirectoryNode(string path, string name)
    {
    	var directoryNode = new TreeNode(name);
    	var directoryListing = GetDirectoryListing(path);
    
    	var directories = directoryListing.Where(d => d.IsDirectory);
        var files = directoryListing.Where(d => !d.IsDirectory);
    
    	foreach (var dir in directories)
    	{
    		directoryNode.Nodes.Add(CreateDirectoryNode(dir.FullPath, dir.Name));
    	}
    	foreach (var file in files)
    	{
    	        directoryNode.Nodes.Add(new TreeNode(file.Name));
    	}
    	return directoryNode;
    }
    
    public IEnumerable<FTPListDetail> GetDirectoryListing(string rootUri)
    {
    	var CurrentRemoteDirectory = rootUri;
    	var result = new StringBuilder();
    	var request = GetWebRequest(WebRequestMethods.Ftp.ListDirectoryDetails, CurrentRemoteDirectory);
    	using (var response = request.GetResponse())
    	{
    		using (var reader = new StreamReader(response.GetResponseStream()))
    		{
    			string line = reader.ReadLine();
    			while (line != null)
    			{
    				result.Append(line);
    				result.Append("\n");
    				line = reader.ReadLine();
    			}
    			if (string.IsNullOrEmpty(result.ToString()))
    			{
    				return new List<FTPListDetail>();
    			}
    			result.Remove(result.ToString().LastIndexOf("\n"), 1);
    			var results = result.ToString().Split('\n');
    			string regex =
    				@"^" +               //# Start of line
    				@"(?<dir>[\-ld])" +          //# File size          
    				@"(?<permission>[\-rwx]{9})" +            //# Whitespace          \n
    				@"\s+" +            //# Whitespace          \n
    				@"(?<filecode>\d+)" +
    				@"\s+" +            //# Whitespace          \n
    				@"(?<owner>\w+)" +
    				@"\s+" +            //# Whitespace          \n
    				@"(?<group>\w+)" +
    				@"\s+" +            //# Whitespace          \n
    				@"(?<size>\d+)" +
    				@"\s+" +            //# Whitespace          \n
    				@"(?<month>\w{3})" +          //# Month (3 letters)   \n
    				@"\s+" +            //# Whitespace          \n
    				@"(?<day>\d{1,2})" +        //# Day (1 or 2 digits) \n
    				@"\s+" +            //# Whitespace          \n
    				@"(?<timeyear>[\d:]{4,5})" +     //# Time or year        \n
    				@"\s+" +            //# Whitespace          \n
    				@"(?<filename>(.*))" +            //# Filename            \n
    				@"$";                //# End of line
    
    			var myresult = new List<FTPListDetail>();
    			foreach (var parsed in results)
    			{
    				var split = new Regex(regex)
    					.Match(parsed);
    				var dir = split.Groups["dir"].ToString();
    				var permission = split.Groups["permission"].ToString();
    				var filecode = split.Groups["filecode"].ToString();
    				var owner = split.Groups["owner"].ToString();
    				var group = split.Groups["group"].ToString();
    				var filename = split.Groups["filename"].ToString();
    				myresult.Add(new FTPListDetail()
    				{
    					Dir = dir,
    					Filecode = filecode,
    					Group = group,
    					FullPath = CurrentRemoteDirectory + "/" + filename,
    					Name = filename,
    					Owner = owner,
    					Permission = permission,
    				});
    			};
    			return myresult;
    		}
    	}
    }
    
    private FtpWebRequest GetWebRequest(string method, string uri)
    {
    	Uri serverUri = new Uri(uri);
    	if (serverUri.Scheme != Uri.UriSchemeFtp)
    	{
    		return null;
    	}
    	var reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
    	reqFTP.Method = method;
    	reqFTP.UseBinary = true;
    	reqFTP.Credentials = new NetworkCredential("yourUser", "yourPassword");
    	reqFTP.Proxy = null;
    	reqFTP.KeepAlive = false;
    	reqFTP.UsePassive = false;
    	return reqFTP;
    }
