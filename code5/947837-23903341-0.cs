    private ShellTileData CreateIconicTileData()
    {
        IconicTileData iconicTileData = new IconicTileData();
        iconicTileData.Count = 11;
        iconicTileData.IconImage = new Uri("/Assets/pizza.lockicon.png", UriKind.Relative);
        iconicTileData.SmallIconImage = new Uri("/Assets/pizza.lockicon.png", UriKind.Relative);
        iconicTileData.WideContent1 = "Wide content 1";
        iconicTileData.WideContent2 = "Wide content 2";
        iconicTileData.WideContent3 = "Wide content 3";
         
        return iconicTileData;
    }
