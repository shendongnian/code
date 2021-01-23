        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            var text = context.Request.Params["text"];
            if (text == null) text = string.Empty;
            var image = CreateBitmapImage(text);
            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }
