    public class ImageService: IImageService
    {
        PhotoChooserTask photoChooserTask;
        public ImageService()
        {
            photoChooserTask = new PhotoChooserTask();
        }        
        public ObservableCollection<PictureModel> RefreshSavedImages()
        {
            // Refreash images from library
        }
        public WriteableBitmap StreamToWriteableBitmap(Stream imageStream)
        {
           ....
        }
        public void PhotoChooserWithCameraServiceShowEventHandler<PhotoResult> CompletedCallback)
        {
            // PhotoChooserTask get source of image.
            photoChooserTask.Completed += CompletedCallback;        
        }
    }
