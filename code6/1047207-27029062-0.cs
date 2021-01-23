    async Task WriteTimestampAsync()
    {
        myTextbox.Text = "saving timestamp";
        Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
        StorageFile sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("dataFile.txt", CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTime.Now)); // THIS LINE THROWS THE ERROR
    }
   ...
  
    async void DoTimeStampStuff()
    {
        await WriteTimestampAsync();
        await ReadTimestampAsync();
    }
