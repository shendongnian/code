    var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = filename, 
            Inline = false, 
        };
    Response.AppendHeader("Content-Disposition", cd.ToString());
    return File(filename, contentType, FullName);
