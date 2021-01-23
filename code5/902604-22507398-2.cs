    CameraCaptureTask cameraCaptureTask;
    cameraCaptureTask = new CameraCaptureTask();
    cameraCaptureTask.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);
    cameraCaptureTask.Show();
    void cameraCaptureTask_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            MessageBox.Show(e.ChosenPhoto.Length.ToString());
    
            //Code to display the photo on the page in an image control named myImage.
            //System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
            //bmp.SetSource(e.ChosenPhoto);
            //myImage.Source = bmp;
        }
    }
