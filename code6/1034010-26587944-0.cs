    var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWidePeekImageAndText01);                
    var tileImageAttributes = tileXml.GetElementsByTagName("image");
    ((XmlElement)tileImageAttributes[0]).SetAttribute("src", "ms-appdata:///local" + wideBackGroundUri.LocalPath);
    var brandingAttribute = tileXml.GetElementsByTagName("binding");
    ((XmlElement)brandingAttribute[0]).SetAttribute("branding", "none");
    tileXml.SelectSingleNode("//text[@id=1]").InnerText = wideBackContent;
    TileNotification tileNotification = new TileNotification(tileXml);
    TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
