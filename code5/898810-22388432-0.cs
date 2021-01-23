    get
    {
        return selected;
    }
    set
    {
        if (selected == value) return;  // use this to not do it again
        selected = value;
        if (selected == AssetTypes.Image)
        {
            image.Click();
        }
        else if (selected == AssetTypes.Video)
        {
            video.Click();
        }
        else
        {
            selected = null;
        }
        // and you should iplement INPC 
        NotifyPropertyChanged("Selected");
    }
}
