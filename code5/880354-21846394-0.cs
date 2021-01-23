    protected virtual void DownloadNDelete(string sFilePath, string sContentType)    
    {   
         
    string FileName = Path.GetFileName(sFilePath);
    Response.Clear();
    Response.AddHeader("Content-Disposition","attachment; filename=" + FileName);
    Response.ContentType = sContentType;
    Response.WriteFile(sFilePath);
    Response.Flush();
    this.DeleteFile(sFilePath);
    Response.End();
    
    }
