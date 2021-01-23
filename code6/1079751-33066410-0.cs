    for (int i = Count; i < Count + count; i++)
    {
        using (var fileStream = await photos[i].OpenAsync(FileAccessMode.Read))
        {
            BitmapImage bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(fileStream);
            this.Add(bitmapImage);
        }
    }
