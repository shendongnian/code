    public class PhotoChooser
    {
        public Task<BitmapImage> ChoosePhoto()
        {
            var taskSource = new TaskCompletionSource<BitmapImage>();
            var chooser = new PhotoChooserTask();
            chooser.Completed += (s, e) =>
                {
                    if (e.ChosenPhoto == null)
                    {
                        taskSource.SetResult(null);
                    }
                    else
                    {
                        BitmapImage bmp = new BitmapImage();
                        bmp.SetSource(e.ChosenPhoto);
                        taskSource.SetResult(bmp);   
                    }
                };
            chooser.Show();
            return taskSource.Task;
        }
    }
