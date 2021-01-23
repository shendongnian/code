       Database master = Sitecore.Configuration.Factory.GetDatabase ("master");
        Item item = master.GetItem ("/sitecore/media library/Images/XXX");
        If (item! = null)
        {
            MediaItem mediaItem = new MediaItem (item);
            img.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl (mediaItem);
        }
