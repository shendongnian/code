    var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150PeekImageAndText01);
    var tileImage = tileXml.GetElementsByTagName("image")[0] as XmlElement;
    tileImage.SetAttribute("src", "ms-appx:///Assets/bild.JPG");
    var tileText = tileXml.GetElementsByTagName("text");  
    var tileNotification = new TileNotification(tileXml);
    TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
