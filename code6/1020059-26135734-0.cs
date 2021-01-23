    private void gallery_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            Image img = new Image();
            BitmapImage tmpBitmap = new BitmapImage();
            tmpBitmap.SetSource(e.ChosenPhoto);
            img.Source = tmpBitmap;
            scrl.Content = img;
            scrl.Opacity = 1.0;
        }
    }
