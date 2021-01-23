        if (!String.IsNullOrEmpty(nameOnly)) {
          string filename = Server.MapPath(nameOnly);
          if (!String.IsNullOrEmpty(filename)) {
            try {
              Response.Buffer = false;
              Response.Clear(); // clear the buffer
              Response.Cache.SetCacheability(HttpCacheability.NoCache);
              if (-1 < filename.IndexOf(".avi")) {
                Response.ContentType = "video/x-msvideo";
              } else if (-1 < filename.IndexOf(".pdf")) {
                Response.ContentType = "Application/pdf";
              } else if (-1 < filename.IndexOf(".rar")) {
                Response.ContentType = "Application/x-rar-compressed";
              } else {
                Response.ContentType = "Application/octet-stream";
              }
              FileInfo file = new FileInfo(filename);
              Response.AddHeader("Content-Disposition", "attachment; filename=" + nameOnly);
              Response.AddHeader("Content-Length", file.Length.ToString());
              Response.WriteFile(file.FullName);
            } catch (Exception err) {
              outputLine = err.Message;
            } finally {
              Response.Flush();
            }
          } else {
            outputLine = string.Format("Server was unable to locate file \"{0}\".", nameOnly);
          }
        }
