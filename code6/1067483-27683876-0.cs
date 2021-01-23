    private void GenerateFile(string strPath)
    {
         var file = new FileInfo(@strPath);
    
         Response.Clear();
         Response.ContentType = "application/vnd.ms-excel";
         Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Name + "\"");
         Response.AddHeader("Content-Length", file.Length.ToString());
         Response.TransmitFile(file.FullName);
         HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
