    var fileInfo = new System.IO.FileInfo(DownloadPath);
    
                if (fileInfo.Exists)
                {
                    Response.Clear();
    
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.BufferOutput = true;
                    Response.TransmitFile(fileInfo.FullName);
                    Response.Flush();
    
                    
                }
                else
                {
                    throw new Exception("File not found");
                }
