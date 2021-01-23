    using (var backgroundSource = new StreamImageSource(stream))
    using (var filterEffect = new FilterEffect(backgroundSource))
    {
    	using (BlendFilter blendFilter = new BlendFilter()) 
    	{
    		var size = new Windows.Foundation.Size(400, 400);
    		var color = Windows.UI.Color.FromArgb(250, 128, 255, 200);
    
    		blendFilter.ForegroundSource = new ColorImageSource(size, color);
    		blendFilter.BlendFunction = BlendFunction.Add;
    
    		filterEffect.Filters = new[] { blendFilter };
    
    		var result = await new JpegRenderer(filterEffect).RenderAsync();
    	}
    }
