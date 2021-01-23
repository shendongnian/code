    var uri = new Uri("http://*******", UriKind.Absolute);
    var http = new HttpClient();
    var stream = http.GetStreamAsync(uri).Result;
    using (var reader = new StreamReader(stream))
    {
         while (!reader.EndOfStream)
         {
             var response = reader.ReadToEnd();
         }
    }
