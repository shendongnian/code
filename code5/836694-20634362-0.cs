    public ActionResult ExcelDoc(string newFilePath)
    {
    	string filepath = newFilePath;
    
    	// Create New instance of FileInfo class to get the properties of the file being downloaded
    	FileInfo file = new FileInfo(filepath);
    
    	// Checking if file exists
    	if (file.Exists)
    	{
    		var fileBytes = System.IO.File.ReadAllBytes(filepath);
    		return File(new MemoryStream(fileBytes), "application/vnd.ms-excel");
    	}
    	else
    	{
    		return Content("File does not exist");
    	}
    }
