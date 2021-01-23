    var data = GetData(); //Get the source data
    var sa = new StreamAdaptor(); //This is what wraps the write-only utility source
    sa.UpstreamSource((ps) => //ps is the dummy stream which does most of the magic
    {
        //This anon. function is run on a separate thread and can therefore be blocked
    	var sw = new StreamWriter(ps);
    	sw.AutoFlush = true;
    	var js = new Newtonsoft.Json.JsonSerializer();
    	js.Serialize(sw, data); //This is the main component of the implementation
    	sw.Flush();
    });
    
    var sa2 = new StreamAdaptor();
    sa2.UpstreamSource((ps) =>
    {
    	using (var gz = new System.IO.Compression.GZipStream(ps, System.IO.Compression.CompressionMode.Compress, true))
    		sa.CopyTo(gz);
    });
    
