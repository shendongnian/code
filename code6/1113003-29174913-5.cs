    var addresses = new List<string> {
        "http://www.example.com/page1",
        "http://www.example.com/page2",
        "http://www.example.com/page3",
    };
    
    var stringBuilder = new StringBuilder();
    var links = new List<LinkLabel.Link>(); 
    foreach (var address  in addresses)
    {
        if (stringBuilder.Length > 0) stringBuilder.AppendLine();
        // We cannot add the new LinkLabel.Link to the LinkLabel yet because
        // there is no text in the label yet, so the label will complain about
        // the link location being out of range. So we'll temporarily store
        // the links in a collection and add them later.
        links.Add(new LinkLabel.Link(stringBuilder.Length, address.Length, address));        
        stringBuilder.Append(address);
    }
    
    var linkLabel = new LinkLabel();
    // We must set the text before we add the links.
    linkLabel.Text = stringBuilder.ToString();
    foreach (var link in links)
    {
        linkLabel.Links.Add(link);
    }
    linkLabel.AutoSize = true;
    linkLabel.LinkClicked += (s, e) => {
        System.Diagnostics.Process.Start((string)e.Link.LinkData);
    };
