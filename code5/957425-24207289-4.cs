    public class ImageHandler : IHttpHandler
    {
    	public void ProcessRequest(HttpContext context)
    	{
    		int id = Convert.ToInt32(context.Request.QueryString["Id"]);
    		var imageBytes = getByteArray(id);
    		using (var stream = new MemoryStream(imageBytes))
    		using (var image = Image.FromStream(stream))
    		{
    			var data = GetEncodedImageBytes(image, ImageFormat.Jpeg);
    
    			context.Response.ContentType = "image/jpeg";
    			context.Response.BinaryWrite(data);
    			context.Response.Flush();
    		}
    	}
    
    	public Byte[] getByteArray(int id)
    	{
    		EmailEntities e = new EmailEntities();
    
    		return e.Email.Find(id).Thumbnail;
    	}
    
    	public byte[] GetEncodedImageBytes(Image image, ImageFormat format)
    	{
    		using (var stream = new MemoryStream())
    		{
    			image.Save(stream, format);
    			return stream.ToArray();
    		}
    	}
    	
    	public bool IsReusable
    	{
    		get { return false; }
    	}
    }
