    using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
    {              
        using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
        {
           writer.WriteBytes((byte[])fileBytes);
           writer.StoreAsync().GetResults();
        }
        var image = new BitmapImage();
        image.SetSource(ms);
    }
