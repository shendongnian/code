    var doc = new HtmlDocument();
    doc.LoadHtml(html);
    
    var root = doc.DocumentNode;
    if (root != null)
    {
        var replace = false;
    
        images = root.SelectNodes("//img[@usemap]");
        if (images != null)
        {
            foreach (var image in images)
            {
                image.ParentNode.RemoveChild(image);
            }
    
            replace = true;
        }
    
        if (replace)
        {
            html = root.OuterHtml;
        }
    }
    
    var newhtml = html;
