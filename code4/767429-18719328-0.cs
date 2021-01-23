    [HttpGet]
    public FileContentResult GetEmployeeImage()
    {
        byte[] image = byteArrayFromImage;
        return new FileContentResult(image , "image/jpeg");
    }
