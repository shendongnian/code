    public JsonResult MyService(StoreImageRequest request)
    {
        var frontImage = HttpContext.Request.Files["front"].InputStream;
        var backImage = HttpContext.Request.Files["front"].InputStream;
    }
