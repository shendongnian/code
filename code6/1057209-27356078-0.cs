    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = filename,
        Inline = false,
    };
    
    Response.AddHeader("Content-Disposition", cd.ToString());
