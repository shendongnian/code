    set
    {        
        if (value == AssetTypes.Image)
        {
            image.Click();
            selected = value;
        }
        else if (value == AssetTypes.Video)
        {
            video.Click();
            selected = value;
        }
        else
        {
            selected = null;
        }
    }
