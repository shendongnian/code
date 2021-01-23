    private static object lockObj = new object();
    private void YourMethod()
    {
        var path = Server.MapPath("File.js"));
    
        lock (lockObj)
        {
            // Create the file if it doesn't exist or if the application has been restarted
            // and the file was created before the application restarted
            if (!File.Exists(path) || ApplicationStartTime > File.GetLastWriteTimeUtc(path))
            {
                var script = "...";
    
                using (var sw = File.CreateText(path))
                {
                    sw.Write(script);
                }
            }
        }
    }
