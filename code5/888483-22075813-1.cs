    public interface IImageService
    {
        ObservableCollection<object> RefreshSavedImages();
        void PhotoChooserWithCameraServiceShow(EventHandler<PhotoResult> CompletedCallback);
    }
