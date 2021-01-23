    public ActionResult Movie()
    {
    	byte[] file = System.IO.File.ReadAllBytes(@"C:\HOME\asp\Java\Java EE. Programming Spring 3.0\01.avi");
    
    	return new RangeFileContentResult(file, "video/x-msvideo", "01.avi", DateTime.Now);
    }
