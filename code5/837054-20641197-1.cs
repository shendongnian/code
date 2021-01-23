    //import the HtmlAgilityPack
    using HtmlAgilityPack;
    HtmlDocument doc = new HtmlDocument();
    
    // Load doc from file:
    doc.Load(pathToFile);
    // Load doc from string:
    doc.LoadHtml(contentsOfFile);
    //Finding things using Linq
    var nodes = doc.DocumentNode.DescenadantAndSelf("input")
        .Where(node => !string.IsNullOrWhitespace(node.Id)
            && node.Attributes["value"] != null
            && !string.IsNullOrWhitespace(node.Attributes["value"].Value));
    //Finding things using XPath
    var nodes = doc.DocumentNode
        .SelectNodes("//input[not(@id='') and not(@value='')]");
