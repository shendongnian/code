     private async void Button7_Click(object sender, RoutedEventArgs e)
        {
            string[] images = new string[] { "Star_00001.png", "Star_00002.png", "Star_00003.png", "Star_00004.png", "Star_00005.png", "Star_00006.png", "Star_00007.png", "Star_00008.png" };
            string path = "Assets/Star/";
            foreach (string file in images)
            {
                string thepath = Path.Combine(path, file);
                await Task.Delay(46);
                BitmapImage Image = new BitmapImage();
                Image.BeginInit();
                Image.UriSource = new Uri(this.BaseUri, thepath);
                Image.CacheOption = BitmapCacheOption.OnLoad;
                Image.EndInit();
                StarImage.Source = Image;
            }
        }
