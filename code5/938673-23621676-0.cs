    using (var client = new WebClient())
    {
        client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; 
               MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; 
              .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
    
        const string url = "http://www.example.com";    
    
         var inputs = new NameValueCollection {
             {"search_div_id", search_term},
         }
    
        var response = client.UploadValues(url, inputs);
        string html = Encoding.UTF8.GetString(response);
    }
