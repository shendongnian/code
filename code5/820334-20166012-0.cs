    String fname;
    FileUpload tempFU = new FileUpload();
    string path = Server.MapPath(@"~\images\" + ulProj.groupCode);
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
    tempFU = (FileUpload)customerUC.FindControl("CustomerLogoUrlFU");        
    fname = System.IO.Path.Combine(path,tempFU.FileName);
    tempFU.SaveAs(fname);
    tempCus.logoUrl = fname;
    
