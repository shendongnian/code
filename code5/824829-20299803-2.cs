    var url = "http://google.com";
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync(url);
    
    HtmlDocument doc = new HtmlDocument();
    doc.Load(await response.Content.ReadAsStreamAsync());
    
    foreach (var selectNode in doc.DocumentNode.SelectNodes("//img[@src]"))
    {
          Console.WriteLine(selectNode.Attributes["src"].Value);
    }
