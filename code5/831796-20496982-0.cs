        //load the main image
        var bmp = new Bitmap(200, 200);
        
        //draw here
        bmp.Save(context.Response.OutputStream, ImageFormat.Png);
        context.Response.ContentType = "image/png";
        context.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        context.Response.Cache.SetNoStore();
