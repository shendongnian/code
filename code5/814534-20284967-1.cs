    var doc = new HtmlAgilityPack.HtmlDocument();
    //Path to the file on the filesystem
    doc.LoadHtml("patch to your htmlfile");
    
    if (!doc.DocumentNode == null)
    {
       foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//li[@class='email']"))
       {
           //add title to your array
           //I recommend using a List<string> instead
           //list.Add(node.innerHtml);
       }
       
    }
