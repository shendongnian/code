    void cameraCaptureTask_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            MediaLibrary medialibrary = new MediaLibrary(); // Don't forget to the "using Microsoft.Xna.Framework.Media;" namespace
            medialibrary.SavePicture("ImageName", e.ChosenPhoto);
        }
    }
