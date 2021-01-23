    void task_Completed(object sender, Microsoft.Phone.Tasks.PhotoResult e)
    {
        if (e.TaskResult == Microsoft.Phone.Tasks.TaskResult.OK)
        {
            BitmapImage source = new BitmapImage();
            source.SetSource(e.ChosenPhoto);
            WriteableBitmap bitmap = new WriteableBitmap(source);
            WriteableBitmap thumbnail = bitmap.Resize(100, 100, WriteableBitmapExtensions.Interpolation.Bilinear); // Creates a 100x100 thumbnail
        }
    }
