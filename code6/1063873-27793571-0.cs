    public async Task<ActionResult> CreateWordFile()
    {
    	LiveLoginResult loginStatus = await authClient.InitializeWebSessionAsync(HttpContext);
    	if (loginStatus.Status == LiveConnectSessionStatus.Connected)
    	{
    		connectedClient = new LiveConnectClient(this.authClient.Session);
    		string url = "https://apis.live.net/v5.0/me/skydrive/files?access_token=" + this.authClient.Session.AccessToken;
    		
    		 MemoryStream streamDoc = new MemoryStream();
    		DocX doc = DocX.Create(streamDoc);
    
    		string headlineText = "Constitution of the United States";
    		string paraOne = ""
    			+ "We the People of the United States, in Order to form a more perfect Union, "
    			+ "establish Justice, insure domestic Tranquility, provide for the common defence, "
    			+ "promote the general Welfare, and secure the Blessings of Liberty to ourselves "
    			+ "and our Posterity, do ordain and establish this Constitution for the United "
    			+ "States of America.";
    
    		// A formatting object for our headline:
    		var headLineFormat = new Formatting();
    		headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
    		headLineFormat.Size = 18D;
    		headLineFormat.Position = 12;
    
    		// A formatting object for our normal paragraph text:
    		var paraFormat = new Formatting();
    		paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
    		paraFormat.Size = 10D;
    
    		doc.InsertParagraph(headlineText, false, headLineFormat);
    		doc.InsertParagraph(paraOne, false, paraFormat);
    
    		doc.Save();
    		
    		var docFile = File(streamDoc, "application/octet-stream", "FileName.docx");
    		MemoryStream streamFile = new MemoryStream();
    		docFile.FileStream.Position = 0;
    		docFile.FileStream.CopyTo(streamFile);
    
    		var bites = streamFile.ToArray();
    		Stream stream2 = new MemoryStream(bites);
    
    		try
    		{
    			LiveOperationResult getResult = await connectedClient.UploadAsync("me/skydrive", docFile.FileDownloadName, stream2, OverwriteOption.Overwrite);
    		}
    		catch(WebException ex)
    		{
    		   
    		}
    	}
    
    	return View("~/Views/Auth/EditFile.cshtml");
    }
