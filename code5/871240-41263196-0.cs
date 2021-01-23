    [System.Web.Http.HttpGet]
    [ActionName("ConvertHTMLToImage")]
    public HttpResponseMessage ConvertHTMLToImage()
    {  
         string filePath = @"C:\temp\mona-lisa.png";
         
         var result = new HttpResponseMessage(HttpStatusCode.OK);
         
         FileStream fileStream = new FileStream(filePath, FileMode.Open);
         Image image = Image.FromStream(fileStream);
         MemoryStream memoryStream = new MemoryStream();
         image.Save(memoryStream, ImageFormat.Jpeg);
         result.Content = new ByteArrayContent(memoryStream.ToArray());
         result.Content.Headers.ContentType = new  MediaTypeHeaderValue("image/jpeg");
         return result;
    }
