    Response.Clear();
    if (Request.Browser != null && Request.Browser.Browser == "IE")
        sFileName = HttpUtility.UrlPathEncode(sFileName);
    // Response.Cache.SetCacheability(HttpCacheability.Public); // that's upon you
    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + sFileName + "\"");
                                                                // ^                   ^
    // Response.AddHeader("Content-Length", new FileInfo(sFilePath).Length.ToString()); // upon you 
    Response.WriteFile(sFilePath);
    Response.Flush();
    Response.End();
