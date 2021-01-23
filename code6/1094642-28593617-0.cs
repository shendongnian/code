    public void ProcessRequest(HttpContext context)
     {
        context.Response.ContentType = "text/plain";
        HttpPostedFile postedFile = context.Request.Files["Filedata"];
        string filename = postedFile.FileName;
        var Extension = filename.Substring(filename.LastIndexOf('.') 
        + 1).ToLower();
        string savepath =HttpContext.Current.Server.MapPath("/images/profile/");
    
        postedFile.SaveAs(savepath + @"\" + user.uid + filename);
     }
