    public FileContentResult Retrive(int imgname)
    {
		return File(ConvertToByteArray(YourFile), "image/png"); //Changed here
    }
    
