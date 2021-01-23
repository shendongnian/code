        public void ProcessRequest(HttpContext context)
        {
            string imgName = context.Request.QueryString["n"];
            context.Response.ContentType = "image/png";
            string path = @"C:\Users\Public\Pictures\Sample Pictures\" + imgName;
            Image image = Image.FromFile(path);
            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }
