    set
    {        
        if (selected == AssetTypes.Image)
        {
            image.Click();
            selected = value;
        }
        else if (selected == AssetTypes.Video)
        {
            video.Click();
            selected = value;
        }
        else
        {
            selected = null;
        }
    }
