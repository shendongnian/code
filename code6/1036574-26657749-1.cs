    ImageButton img = (ImageButton)sender;
    string file = img.CommandArgument;
    String imgURLtoDownload = @"img/uploads/"+file;
    byte[] data= GetFileContent(Server.MapPath(imgURLtoDownload));
    Response.Clear();
    Response.AddHeader("Content-Disposition", "attachment; filename=" + file);
    Response.ContentType = System.Web.MimeMapping.GetMimeMapping(Server.MapPath(imgURLtoDownload));     
    Response.BinaryWrite(data);
    Response.End();
    public byte[] GetFileContent(string Filepath)
    {
        return System.IO.File.ReadAllBytes(Filepath);
    }
