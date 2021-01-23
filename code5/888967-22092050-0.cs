    private void openReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        UnZipper unzip = new UnZipper(e.Result);
        foreach (string filename in unzip.GetFileNamesInZip())
        {
            Stream stream = unzip.GetFileStream(filename);
            BitmapImage image = new BitmapImage();
            image.SetSource(stream);
            imgCtr.Source = image;    
        }
    }
