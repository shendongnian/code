    private void MethodA()
    {
        // Choose Photo, I edited it and after saved it.
        imageService.PhotoChooserWithCameraServiceShow(photoChooserTask_Completed);
    }
    // this is your callback
    void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                // Refreash the library and Bind it in my ItemSource from my ListBox.
                PictureList = imageService.RefreshSavedImages();
            }
        }
   
