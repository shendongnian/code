    int offset = this.Count;
    for (int i = offset; i < offset + count && i < photos.Count; i++)
    {
        using (var fileStream = await photos[i].OpenAsync(FileAccessMode.Read))
        {
            BitmapImage bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(fileStream);
            this.Add(bitmapImage);
        }
    }
