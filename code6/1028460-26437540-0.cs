    public async Task UploadPhotoContinueAsync(IEnumerable<StorageFile> files)
    {
    	var uri = string.Format("https://api.500px.com/v1/photos/upload?name={0}&description={1}&privacy=0&category=0", "test name", "test description");
    	var backgroudUploader = new BackgroundUploader();
    	var headers = OAuthUtility.BuildBasicParameters(consumerKey, consumerSecret, uri, HttpMethod.Post, GetAccessToken());
    	var header = string.Empty;
    	var file = files.First();
    	foreach (var item in headers)
    	{
    		header += string.Format(@"{0}=""{1}"", ", item.Key, item.Value);
    	}
    
    	header = header.Remove(header.Length - 2);
    
    	backgroudUploader.SetRequestHeader("Authorization", string.Format("OAuth {0}", header));
    	backgroudUploader.SetRequestHeader("Filename", file.Name);
    	string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
    	backgroudUploader.SetRequestHeader("Content-Type", "multipart/form-data; boundary=" + boundary);
    	backgroudUploader.Method = "POST";
    
    	var parts = new List<BackgroundTransferContentPart>();
    	var part = new BackgroundTransferContentPart();
    	part.SetHeader("Content-Disposition", @"form-data; name=""file""; filename=""" + file.Name + "\"");
    	part.SetFile(file);
    	parts.Add(part);
    
    	var op = await backgroudUploader.CreateUploadAsync(new Uri(uri), parts, "", boundary);
    	try
    	{
    		var result = await op.StartAsync();
    	}
    	catch (Exception ex)
    	{
    		Debug.WriteLine(ex.Message);
    	}
    }
