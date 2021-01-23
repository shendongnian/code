    string filename = "filename";
    string completePath = Server.MapPath(filename);
     
    if (System.IO.File.Exists(completePath))
    {
         Response.Clear();
         Response.AddHeader("Content-Disposition","attachment; filename=" + filename );
         //Type of the file, whether it is exe, pdf, jpeg etc etc
         Response.ContentType = "application/octet-stream";
         Response.WriteFile(completePath);
         Response.Flush();
         Response.End();
         System.IO.File.Delete(completePath);    
    }
