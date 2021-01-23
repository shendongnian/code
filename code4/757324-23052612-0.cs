    var fileInfo = new System.IO.FileInfo(oFullPath);
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"", yourfilename));
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.WriteFile(oFullPath);
                Response.End();
