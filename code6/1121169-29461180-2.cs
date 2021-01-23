    public class File
    {
    	public string FilelastModified { get; set; }//: '1428117254000',
    	public string LastModifiedDate { get; set; }//: 'Fri Apr 03 2015 23:14:14 GMT-0400 (Eastern Daylight Time)',
    	public string Name { get; set; }//: "__image.jpg",
    	public string Size { get; set; }//: '15426',
    	public string Type { get; set; }//: "image/jpeg",
    	public string WebkitRelativePath { get; set; }//: ""
    }
    public class Image
    {
    	public string Url { get; set; }//'blob:http%3A//localhost%3A52646/463f234c-53da-4cef-bbda-1aee44777d5d',
    	public string DataURL { get; set; } //: 'data:image/jpeg;base64,/9j/4AAQSkZJRg.../5ZUUUVoAU5OlFFZgOqnPGvm9KKKADy18vpUc9FFaAOs53z941eooomB//Z',
    	public string ImageData { get; set; }
    	public File File { get; set; }
    }
    
    public JsonResult UploadPhoto(string imageJson)
    {
    
    	Image imageObject = new  JavaScriptSerializer().Deserialize<Image>(imageJson);
    	imageObject.ImageData = imageObject.DataURL.Substring(imageObject.DataURL.IndexOf("base64,") + "base64,".Length);
    	byte[] bytes = Convert.FromBase64String(imageObject.ImageData);
    	Guid guid = Guid.NewGuid();
    	var fileName = guid  + "_" + imageObject.File.Name ;
    	System.Drawing.Image imageDrawing;
    	using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
    	{
    		imageDrawing = System.Drawing.Image.FromStream(ms);
    
    
    		var dirName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data"), roomId.ToString());
    		if (!Directory.Exists(dirName))
    			Directory.CreateDirectory(dirName);
    		string fileNameWitPath = System.IO.Path.Combine(dirName, fileName);
    		//ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Png;
    		imageDrawing.Save(fileNameWitPath);
    		
    	}
    	
    	return Json(new { result = 1 });
    }
