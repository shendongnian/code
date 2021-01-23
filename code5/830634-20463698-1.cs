    WebRequest request = WebRequest.Create(strURL);
    WebResponse response = request.GetResponse();
    Stream data = response.GetResponseStream();
    
    string html = String.Empty;
    using (StreamReader sr = new StreamReader(data))
    {
      html = sr.ReadToEnd();
    }
    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
    document.LoadHtml(html);
 
    // to remove all tags 
    var result = document.DocumentNode.InnerText;
    // to remove script tags inside body 
    document.DocumentNode.SelectSingleNode("//body").Descendants()
                    .Where(n => n.Name == "script")
                    .ToList()
                    .ForEach(n => n.Remove());
