        using Microsoft.Phone.Tasks;
        using System.IO;
        using System.Windows.Media.Imaging;
        ...
        PhotoChooserTask selectphoto = null;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            selectphoto = new PhotoChooserTask();
            selectphoto.Completed += new EventHandler(selectphoto_Completed);
            selectphoto.Show();
        }
        void selectphoto_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BinaryReader reader = new BinaryReader(e.ChosenPhoto);
                image1.Source = new BitmapImage(new Uri(e.OriginalFileName));
            }
        }
