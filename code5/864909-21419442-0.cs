    // Posting update
    int tileTagId = 0;
    foreach ( XmlDocument XmlTile in AllTiles )
    {
    	TileNotification tileNotification = new TileNotification( XmlTile );
    	tileNotification.Tag = tileTagId.ToString();
    	TileUpdater secondaryTileUpdater = TileUpdateManager.CreateTileUpdaterForSecondaryTile( AppTileId );
        //TileUpdater secondaryTileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
    	secondaryTileUpdater.EnableNotificationQueue( true );
    	secondaryTileUpdater.Update( tileNotification );
    	tileTagId++;
    }
