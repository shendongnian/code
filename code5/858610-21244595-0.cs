    using HtmlAgilityPack;
    
    
    string Price;
    HtmlWeb Sitehtml = new HtmlWeb();
    HtmlDocument document = new HtmlDocument();
    document = Sitehtml.Load(SITE_ADDRESS); // Site address can be like this : http://www.nerkhyab.com
    HtmlNode node = document.DocumentNode.SelectSingleNode("//h2");//recognizing Target Node
    Price = node.InnerHtml;//put text of target node in variable
