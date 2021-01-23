    HttpContext context = HttpContext.Current;
    context.Response.Clear();
    context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1256");
    context.Response.Charset = "windows-1256"; //ISO-8859-13 ISO-8859-9  windows-1256
    
