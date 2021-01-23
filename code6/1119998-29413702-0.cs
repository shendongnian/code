    // note: this code is completely untested, i don't even know whether it compiles
    using (var webResponse = request.GetResponse())
    using (var webStream = webResponse.GetResponseStream())
    {
        if (webStream != null)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"test.pdf\"");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            webStream.CopyTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
