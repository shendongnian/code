    public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Request.InputStream.Length() //17 here
            string jsonPostData;
            var stream = request.InputStream;
            var reader = new System.IO.StreamReader(stream);
            jsonPostData = reader.ReadToEnd();
            filterContext.HttpContext.InputStream.Length() //17 here
            filterContext.HttpContext.Request.InputStream.Position = 0; //17 here
    
      base.OnAuthorization(filterContext); //so when the request reaches controller its empty
    }
