    PhotoChooserTask chooser;
    public TaskPage()
    {
        InitializeComponent();
        chooser = new PhotoChooserTask();
        chooser.Completed += gallery_Completed;
    }
    private void gallery_click(object sender, EventArgs e)
    {
        chooser.Show();
    }
    private void gallery_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            BitmapImage tmpBitmap = new BitmapImage();
            tmpBitmap.SetSource(e.ChosenPhoto);
            mtpImg.Source = tmpBitmap;
        }
    }
