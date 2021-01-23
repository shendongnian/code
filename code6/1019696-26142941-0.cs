    public async Task Resize(string name, string width, string height, ImageOptions options, Func<Images, Task> callback)
    {
    	var actionName = "resized";
    	var newWidth = Convert.ToInt32(width);
    	var newHeight = string.IsNullOrEmpty(height) ? newWidth : Convert.ToInt32(height);
    	var resizedName = ApplyOptionName(string.Format("{0}-{3}-{1}x{2}", name, newWidth, newHeight, actionName), options);
    
    	await Get(resizedName, null, async (previousImage) =>
    	{
    		Images resizedImage = null;
    
    		if (previousImage != null)
    		{
    			resizedImage = previousImage;
    		}
    		else
    		{
    			await Get(name, null, async (image) =>
    			{
    				if (image == null)
    				{
    					resizedImage = null;
    					return;
    				}
    
    				using (ImageFactory imageFactory = new ImageFactory())
    				{
    					imageFactory.Load(image.ToStream());
    
    					imageFactory.Resize(new ResizeLayer(new Size(newWidth, newHeight), ResizeMode.Max, AnchorPosition.Left));
    
    					ProcessImageOptions(imageFactory, options);
    
    					using (MemoryStream ms = new MemoryStream())
    					{
    						imageFactory.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    
    						resizedImage = await CreateAsync(new Images(ms) { Name = resizedName });
    					}
    				}
    
    			});
    		}
    
    		await callback(resizedImage);
    
    	});
    
    }
