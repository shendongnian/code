    [HttpPost]
    public FileStreamResultGetCSV(DataTable dt)
    {
       MemoryStream stream = Export.GetCSV(dt);
    
       var filename = "ExampleCSV.csv";
       var contenttype = "text/csv";
    
       Response.Clear();
       Response.ContentType = contenttype;
       Response.AddHeader("content-disposition", "attachment;filename=" + filename);
       Response.Cache.SetCacheability(HttpCacheability.NoCache);
       Response.BinaryWrite(stream.ToArray());
       Response.End();
    }
