    private async void downURL()
    {
        try
        {                   
                            LiveDownloadOperationResult operationResult = await client.DownloadAsync(item.id + "/Content?type=notebook");
                            
                            StreamReader reader = new StreamReader(operationResult.Stream);
                            string Content = await reader.ReadToEndAsync(); 
        }
        catch { }
    }
