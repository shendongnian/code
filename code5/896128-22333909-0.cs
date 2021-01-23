    private Dictionary<string, BitmapImage> preload;
    .
    .
    .
 
    public void PreloadImages(BaseUri, path)
    {
    	if (!preload.ContainsKey(path))
    	{
    		var uri = new Uri(BaseUri, path);
    		var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
    
    		IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
    		BitmapImage bmp = new BitmapImage();
    		if (!preload.ContainsKey(path))
    			preload.Add(path, bmp);
    	}
    }
    public BitmapImage ImageFromRelativePath(Uri BaseUri, string path)
    {
    	if (preload.ContainsKey(path))
    	{
    		return preload[path];
    	}
    	else
    	{
    		var uri = new Uri(BaseUri, path);
    		BitmapImage bmp = new BitmapImage();
    		bmp.UriSource = uri;
    		return bmp;
    	}
    }
