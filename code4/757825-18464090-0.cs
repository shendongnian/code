    using (var s = new System.IO.MemoryStream()) {   
      var ctx = (HttpContextBase)actionContext.Request.Properties["MS_HttpContext"];  
      ctx.Request.InputStream.Seek(0, System.IO.SeekOrigin.Begin);  
      ctx.Request.InputStream.CopyTo(s);   var body =
      System.Text.Encoding.UTF8.GetString(s.ToArray()); 
    }
