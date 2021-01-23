    private void Image_Click(object sender, RoutedEventArgs e)
    {
        ShowNextToWatchImage = GetNextImage();
    }
    private Image GetNextImage()
    {
        var found = false;
        Image nextToWatchImage = null;
        foreach (var folder in Folders)
        {
            foreach (var image in folder.Images)
            {
                if (!image.ImageHasBeenViewed)
                {
                    nextToWatchImage = image;
                    found = true;
                    break;
                }
                nextToWatchImage = image;
            }
            if (found)
            {
                break;
            }
        }
        return nextToWatchImage;        
    }
