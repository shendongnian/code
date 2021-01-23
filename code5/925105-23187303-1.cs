        private void flickr1Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ImageStore.Current.Image = (BitmapImage)flickr1Image.Source;
            NavigationService.Navigate(new Uri("/flickrPage.xaml", UriKind.Relative));
        }
