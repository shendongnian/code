    private void Image_Drop_1(object sender, DragEventArgs e)
        {
            string[] fileSource= (string[])e.Data.GetData(DataFormats.FileDrop);
            imgBear.Source = new BitmapImage(new Uri(filex[0], UriKind.Absolute));
        }
