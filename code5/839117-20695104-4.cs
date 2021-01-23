    var extension = !String.IsNullOrEmpty(Settings.Media.RequestExtension)
                                    ? Settings.Media.RequestExtension
                                    : ((MediaItem)item).Extension;
    
    var dynamicMediaUrl = String.Format(
                             "{0}{1}.{2}", 
                             MediaManager.MediaLinkPrefix, 
                             item.ID.ToShortID(), 
                             extension);
