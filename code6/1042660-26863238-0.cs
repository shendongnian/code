    string sFile = Image1.ImageUrl;
    if (string.IsNullOrEmpty(sFile))
    {
       return;
    }
    FileInfo fi = new FileInfo(Server.MapPath(sFile));
    if (!fi.Exists)
    {
       return;
    }
    if (!string.IsNullOrEmpty(sFile))
    {
       // check if the file is an image
       NameValueCollection imageExtensions = new NameValueCollection();
       imageExtensions.Add(".jpg", "image/jpeg");
       imageExtensions.Add(".gif", "image/gif");
       imageExtensions.Add(".png", "image/png");
       if (imageExtensions.AllKeys.Contains(fi.Extension))
       {
           Response.ContentType = imageExtensions.Get(fi.Extension);
           Response.AppendHeader("Content-Disposition", "attachment; filename=" + fi.Name);
           Response.TransmitFile(fi.FullName);
           Response.End();
       }
       Response.Redirect(sFile);
    }
