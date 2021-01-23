    //import the HtmlAgilityPack
    using HtmlAgilityPack;
    HtmlDocument doc = new HtmlDocument();
    
    // Load your data
    // -----------------------------
    // Load doc from file:
    doc.Load(pathToFile);
    
    // OR
    
    // Load doc from string:
    doc.LoadHtml(contentsOfFile);
    // -----------------------------
 
    // Find what you're after
    // -----------------------------
    // Finding things using Linq
    var nodes = doc.DocumentNode.DescendantsAndSelf("input")
        .Where(node => !string.IsNullOrWhitespace(node.Id)
            && node.Attributes["value"] != null
            && !string.IsNullOrWhitespace(node.Attributes["value"].Value));
    // OR
    // Finding things using XPath
    var nodes = doc.DocumentNode
        .SelectNodes("//input[not(@id='') and not(@value='')]");
    // -----------------------------
    // looping through the nodes:
    // the XPath interfaces can return null when no nodes are found
    if (nodes != null) 
    { 
        foreach (var node in nodes)
        {
            var id = node.Id;
            var value = node.Attributes["value"].Value;
        }
    }
