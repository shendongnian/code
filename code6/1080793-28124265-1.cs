    public async Task<Bitmap> DownloadBitmapAsync(string uri)
    {
    	var httpClient = new HttpClient();
    	var response = await httpClient.GetAsync(uri);
    	using (var responseStream = await response.Content.ReadAsStreamAsync())
    	{
    		return new Bitmap(responseStream);
    	}
    }
