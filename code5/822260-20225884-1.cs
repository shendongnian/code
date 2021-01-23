    private void choosenImage(object sender, PhotoResult e)
    {
        if (e.TaskResult != TaskResult.OK ) 
        { 
            return;
        }
        Stream theCopy = new Stream();
        e.ChosenPhoto.CopyTo(theCopy);
        e.ChosenPhoto.Seek( 0, SeekOrigin.Begin );
        _imageBitmap.SetSource(e.ChosenPhoto);
        dummyImage.Source = _thumbImageBitmap;
        MediaLibrary library = new MediaLibrary();
        library.SavePictureToCameraRoll(String, theCopy);
    }
