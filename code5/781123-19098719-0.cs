    private void btn_Click_1(object sender, RoutedEventArgs e)
        {
            BitmapImage img = new BitmapImage();
            imagebitmap = new WriteableBitmap(btn, null);
           
            imagebitmap.SaveToMediaLibrary("hello", false);
           
        }
