    // on Windows 8
    // input data
    int[] value = { 2, 5, 7, 9, 42, 101 };
    // persist data
    string json = JsonConvert.SerializeObject(value);
    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myData.json", CreationCollisionOption.ReplaceExisting);
    await FileIO.WriteTextAsync(file, json);
    // read back data
    string read = await PathIO.ReadTextAsync("ms-appdata:///local/myData.json");
    int[] values = JsonConvert.DeserializeObject<int[]>(read);
    // on Windows Phone 8
    // input data
    int[] value = { 2, 5, 7, 9, 42, 101 };
    // persist data
    string json = JsonConvert.SerializeObject(value);
    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myData.json", CreationCollisionOption.ReplaceExisting);
    using (Stream current = await file.OpenStreamForWriteAsync())
    {
        using (StreamWriter sw = new StreamWriter(current))
        {
            await sw.WriteAsync(json);
        }
    }
    // read back data
    StorageFile file2 = await ApplicationData.Current.LocalFolder.GetFileAsync("myData.json");
    string read;
    using (Stream stream = await file2.OpenStreamForReadAsync())
    {
        using (StreamReader streamReader = new StreamReader(stream))
        {
            read = streamReader.ReadToEnd();
        }
    }
    int[] values = JsonConvert.DeserializeObject<int[]>(read);
