        var TileMgr = TileUpdateManager.CreateTileUpdaterForApplication();
        TileMgr.Clear();
        var tileTemplate = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Image);
            
        // Quitamos el nombre de la app.
        XmlElement tmp = tileTemplate.GetElementsByTagName("visual")[0] as XmlElement;
        tmp.SetAttribute("branding", "none");
        var notification = new TileNotification(tileTemplate);
        TileMgr.Update(notification);
  
