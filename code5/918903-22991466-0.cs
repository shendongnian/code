    @using (Html.BeginForm("UploadImage", "User", FormMethod.Post,
        new
        {
            enctype = "multipart/form-data",
            id = "ImgForm",
            name = "ImgForm",
            target = "UploadTarget",
            style = "display:none;"
        }))
    {
        <h3>Upload Image</h3>
        <input type="file" name="ImageFile" id="ImageFile" />
    
    }
    <iframe id="UploadTarget" name="UploadTarget" style="position: absolute; left: -999em; top: -999em;"></iframe>
    public void UploadImage(HttpPostedFileBase imageFile)
    {
    	if (imageFile != null)
    	{
    		byte[] logo = new byte[imageFile.ContentLength];
    		imageFile.InputStream.Read(logo, 0, imageFile.ContentLength);
    		...
    	}
    }
