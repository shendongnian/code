    var picker = new FileOpenPicker();
    picker.FileTypeFilter.Add(".txt");
    var file = await picker.PickSingleFileAsync();
    var stream = (await file.OpenAsync(FileAccessMode.ReadWrite)) as FileRandomAccessStream;
    stream.Size = 0;
    var writer = new DataWriter(stream.GetOutputStreamAt(0));
    writer.WriteString("Hello\r\n");
    await writer.StoreAsync();
