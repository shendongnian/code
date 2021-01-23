    [HttpPost]
    public FileStreamResult GetCSV(someType param)
    {
       var dt = MyGetDt(param);
       MemoryStream stream = Export.GetCSV(dt);
    
       var filename = "ExampleCSV.csv";
       var contenttype = "text/csv";
       return new FileStreamResult(stream, contenttype)
       {FileDownloadName = filename};
    }
