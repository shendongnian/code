    private StringBuilder payload = null;
    private async void processAsync()
    {
        var r = new Random (DateTime.Now.Ticks.GetHashCode());
        //generate a random string of 108kb
        payload=new StringBuilder();
        for (var i = 0; i < 54000; i++)
            payload.Append( (char)(r.Next(65,90)));
        //create a unique file
        var fname = "";
        do
        {
            //fname = @"c:\source\csharp\asyncdemo\" + r.Next (1, 99999999).ToString () + ".txt";
            fname =  r.Next (1, 99999999).ToString () + ".txt";
        } while(File.Exists(fname));            
        //write the string to disk in async manner
        using(FileStream fs = new FileStream(fname,FileMode.CreateNew,FileAccess.Write, FileShare.None,
            bufferSize: 4096, useAsync: true))
        {
            var bytes=(new System.Text.ASCIIEncoding ()).GetBytes (payload.ToString());
            await fs.WriteAsync (bytes,0,bytes.Length);
            fs.Close ();
        }
        //read the string back from disk in async manner
        payload = new StringBuilder ();
        //FileStream ;
        //payload.Append(await fs.ReadToEndAsync ());
        using (var fs = new FileStream (fname, FileMode.Open, FileAccess.Read,
                   FileShare.Read, bufferSize: 4096, useAsync: true)) {
            int numRead;
            byte[] buffer = new byte[0x1000];
            while ((numRead = await fs.ReadAsync (buffer, 0, buffer.Length)) != 0) {
                payload.Append (Encoding.Unicode.GetString (buffer, 0, numRead));
            }
        }
        //fs.Close ();
        //File.Delete (fname); //remove the file
    }
    public void ProcessRequest (HttpContext context)
    {
        Task task = new Task(processAsync);
        task.Start ();
        task.Wait ();
        //write the string back on the response stream
        context.Response.ContentType = "text/plain";
        context.Response.Write (payload.ToString());
    }
