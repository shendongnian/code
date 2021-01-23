        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            var image = CreateBitmapImage("Hello world");
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            context.Response.BinaryWrite(ms.ToArray());
        }
