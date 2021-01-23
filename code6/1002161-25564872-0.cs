    SecondaryTile tileData = new SecondaryTile()
    {
        TileId = "MyTileID",
        DisplayName = "MyTilesTitle",
        Arguments = "Some arguments"
    };
    tileData.VisualElements.Square150x150Logo = new Uri("uri to image");
    await tileData.RequestCreateAsync();
