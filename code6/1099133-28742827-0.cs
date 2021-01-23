    if (file.Count > 0)
    {          
        foreach (StorageFile f in file)
        {
            ImageProperties properties = await f.Properties.GetImagePropertiesAsync();
            WriteableBitmap bmp = new WriteableBitmap((int)properties.Width, (int)properties.Height);
            bmp.SetSource(await f.OpenReadAsync());
            // Ready to go with bmp
        }
    }
