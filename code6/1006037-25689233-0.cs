    HtmlWeb hw = new HtmlWeb();
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc = hw.Load(tb_url.Text);
    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
    {
        // Get the value of the HREF attribute
        string hrefValue = link.GetAttributeValue( "href", string.Empty );
        cbl_items.Items.Add(hrefValue);
    }
