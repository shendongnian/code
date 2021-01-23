    if (item != null)
                {
                    imageData = item.Image.ToArray();
                    context.Response.ContentType = "image/jpeg";
                    context.Response.BinaryWrite(imageData);
                }
                else
                {
                    //get images from images named folder and parse it to byte array
                 imageData =System.IO.File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath("~/Images/DefaultImage.jpg"));
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(imageData);
                }
    
        
        
