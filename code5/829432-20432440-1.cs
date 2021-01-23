    private void Image_Drop_1(object sender, DragEventArgs e)
        {
            string[] fileSource= (string[])e.Data.GetData(DataFormats.FileDrop);
            myImage.Source = new BitmapImage(new Uri(fileSource[0], UriKind.Absolute));
        }
