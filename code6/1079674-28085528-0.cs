    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
    
    var data = new byte[(int)stream.Length];
    
    stream.Read(data, 0, System.Convert.ToInt32(stream.Length));
    
    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = yourfilename,
        Inline = false,
    };
    
    Response.AddHeader("Content-Disposition", cd.ToString());
