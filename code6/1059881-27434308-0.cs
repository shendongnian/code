    public async Task<ActionResult> ImportDevicesAsync()
    {
    	var csvFile = Request.Files[0] as HttpPostedFileBase;
    	if(csvFile != null && csvFile.ContentLength != 0)
    	{
    		// Note: I would recommend you do not do this here but in a helper class
    		// for this to work, SaveCSVDeviceDataAsync *must* return a Task<object>()
    		var result = await CADC.SaveCSVDeviceDataAsync(csvFile.InputStream);
    		var csvString = result.ToString();
    		var encoding = new UTF8Encoding();
    		var bytes = encoding.GetBytes(csvString);
    		// if you are returning a csv, return MIME type text/csv
    		return File(bytes, "text/txt", "ImportResults.txt");
    	}
    
    	// If the file is null / empty, then you should return
    	// a validation error
    	return Error(500, ...);
    }
