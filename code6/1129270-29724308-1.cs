    private async void write_Click(object sender, RoutedEventArgs e)
    {
        await WriteToFile();
    }
    
    private StorageFile file;
    private async Task WriteToFile()
    {
        // Create a new file named "outputFile.txt"
        file = await ApplicationData.Current.LocalFolder.CreateFileAsync("outputFile.txt", CreationCollisionOption.OpenIfExists);
    
        // Get the string in inputBx
        string toWrite;
        inputTxtBx.Document.GetText(TextGetOptions.AdjustCrlf, out toWrite);
    
        // Write the data from the textbox
        using(var stream = await file.OpenStreamForWriteAsync())
        {
            using(var writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(toWrite);
            }
        }
    
        inputTxtBx.Document.SetText(TextSetOptions.ApplyRtfDocumentDefaults, "");
    }
    
    private async void read_Click(object sender, RoutedEventArgs e)
    {
        if(file == null)
        {
            outputTxtBlk.Text = "You have to write first!";
        }
        else
        {
            // Read the data from disk
            using(var stream = await file.OpenStreamForReadAsync())
            {
                using(var reader = new StreamReader(stream))
                {
                    outputTxtBlk.Text = await reader.ReadToEndAsync();
                }
            }
        }
    }
    
    private async void delete_Click(object sender, RoutedEventArgs e)
    {
        if(file == null)
        {
            outputTxtBlk.Text = "You have to write first!";
        }
        else
        {
            await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
            outputTxtBlk.Text = "File purged forever!";
            file = null;
        }
    }
