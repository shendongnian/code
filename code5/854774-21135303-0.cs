    Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
     Response.AddHeader("Content-Length", file.Length.ToString());
     Response.ContentType = "application/vnd.ms-excel";
     Response.WriteFile(file.FullName);
     Response.End();
