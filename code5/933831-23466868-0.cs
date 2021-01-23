    public partial class MainPage : PhoneApplicationPage
    {
        string tag;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private void photoChooserBtn_Click(object sender, RoutedEventArgs e)
        {
            photoChooserTask = new PhotoChooserTask();
            tag = (sender as Button).Name;
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            photoChooserTask.Show();
        }
        private void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                imagecontrol.Source = bmp;
                switch(tag)
                {
                    case tag1:
                    case tag2:
                    ........
                }
                tag = null;
            }
        }
