    FileInfo fileInfo = new FileInfo(filePath);
    Response.Clear();
    Response.ContentType = "Application/msword";
    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
    Response.WriteFile(fileInfo.FullName);
    Response.End();
