    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    
    public class BitmapImageHandler : IHttpHandler
    {
    	public void ProcessRequest(HttpContext context)
    	{
    	   // you can pass desired dimension as querystring params if the image
           // needs to be with dynamic dimensions.
    	   int width = int.Parse(context.Request.QueryString["width"]); 
    	   int height = int.Parse(context.Request.QueryString["height"]);
    
    	   using (Bitmap bitmap = new Bitmap(width,height))
    	   {
    
    			/*code to generate the bitmap image*/
    
    			using (MemoryStream mem = new MemoryStream()) 
    			{
                    //Save the bitmap in the desired format
    				bitmap.Save(mem, ImageFormat.Png);
    				mem.Seek(0, SeekOrigin.Begin);
                    // set the desired content type for the output
    				context.Response.ContentType = "image/png"; 
                    
    				mem.CopyTo(context.Response.OutputStream, 4096);
    				context.Response.Flush();
    			}
    		}
    	}
    }
