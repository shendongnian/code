    private void tbLink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WebClient client = new WebClient();
        client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
        client.OpenReadAsync(new Uri((sender as TextBlock).Text));
    }
    void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        var resInfo = new StreamResourceInfo(e.Result, null);
        var reader = new StreamReader(resInfo.Stream);
        byte[] contents;
        using (BinaryReader bReader = new BinaryReader(reader.BaseStream))
        {
            contents = bReader.ReadBytes((int)reader.BaseStream.Length);
        }
        IsolatedStorageFileStream stream = file.CreateFile("file.jpg");
        stream.Write(contents, 0, contents.Length);
        stream.Close();
    }
