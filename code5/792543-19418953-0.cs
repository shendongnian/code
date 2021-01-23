    void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                //save the bitmapImage 
                PhoneApplicationService.Current.State["yourparam"] = bmp;
              
            }
            else
            {
                MessageBox.Show("Image Loading Failed.");
            }
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
