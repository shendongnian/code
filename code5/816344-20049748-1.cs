    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        string UserDirectory = @"c:\Users\exampleuser\";
        using (StreamReader SourceReader = File.OpenText(UserDirectory + "BigFile.txt"))
        {
            using (StreamWriter DestinationWriter = File.CreateText(UserDirectory + "CopiedFile.txt"))
            {
                await CopyFilesAsync(SourceReader, DestinationWriter);
            }
        }
    }
    public async Task CopyFilesAsync(StreamReader Source, StreamWriter Destination) 
    { 
        char[] buffer = new char[0x1000]; 
        int numRead; 
        while ((numRead = await Source.ReadAsync(buffer, 0, buffer.Length)) != 0) 
        {
            await Destination.WriteAsync(buffer, 0, numRead);
        } 
    } 
