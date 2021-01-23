    private void choosenImage(object sender, PhotoResult e)
    {
        if (e.TaskResult != TaskResult.OK ) 
        { 
            return;
        }
        _imageBitmap.SetSource(e.ChosenPhoto);
        dummyImage.Source = _thumbImageBitmap;
        MediaLibrary library = new MediaLibrary();
        library.SavePictureToCameraRoll(String, e.ChosenPhoto);
    }
