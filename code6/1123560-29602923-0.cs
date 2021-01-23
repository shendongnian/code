    using (FileStream fs = File.OpenRead(path)) 
    { 
    int length = (int)fs.Length; 
    byte[] buffer; 
    
    using (BinaryReader br = new BinaryReader(fs)) 
    { 
    buffer = br.ReadBytes(length); 
    } 
    
    Response.Clear(); 
    Response.Buffer = true; 
    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", Path.GetFileName(path))); 
    Response.ContentType = "application/" + Path.GetExtension(path).Substring(1); 
    Response.BinaryWrite(buffer); 
    Response.End() 
    }
