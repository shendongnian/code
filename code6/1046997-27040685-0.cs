      public void Downloadfile(string sFileName, string sFilePath)
     {
        var file = new System.IO.FileInfo(sFilePath);
    
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + sFileName);
        Response.AddHeader("Content-Length", file.Length.ToString(CultureInfo.InvariantCulture));
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.End();
      }
