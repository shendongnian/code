    set
    {        
        if (value == AssetTypes.Image || value == AssetTypes.Video)
        {
            video.Click();
            selected = value;
        }
        else
        {
            selected = null;
        }
    }
