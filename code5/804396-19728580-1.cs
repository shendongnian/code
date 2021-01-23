	[HttpPost]
	public async Task<string> Upload()
	{
		var provider = new MultipartFormDataMemoryStreamProvider();
		await Request.Content.ReadAsMultipartAsync(provider);
		var myParameter = provider.FormData.GetValues("myParameter").FirstOrDefault();
		var count = provider.FileData.Count;
	    return count + " / " + myParameter;
	}
