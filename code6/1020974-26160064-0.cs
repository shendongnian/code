    FileStream fs = File.OpenRead(filename);
    
    int length = (int)fs.Length;
    BinaryReader br = new BinaryReader(fs);
    byte[] buffer = br.ReadBytes(length);
    
    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.ContentEncoding = reader.CurrentEncoding;
    Response.ContentType = "application/pdf";            
    Response.AddHeader("Content-Disposition", "inline; filename=" + Request.QueryString["name"]);
    Response.BinaryWrite(buffer);
