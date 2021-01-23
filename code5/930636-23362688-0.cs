    using(var conf = System.IO.File.Create("config.conf"))
    {
        using (var rd = new System.IO.StreamReader(conf))
        {
            // Do whatever you want to do with the file here
        }
    
    }
