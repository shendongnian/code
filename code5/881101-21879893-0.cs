    public async Task<String> FileToBase64Async(String filePath)
    {
        String convertedFile = "";
    
        var client = new WebClient();
        
        Task taskA = Task.Factory.StartNew(() => client.OpenReadCompleted += async (object sender, OpenReadCompletedEventArgs e) =>
        {
            var buffer = await webclient.DownloadDataTaskAsync(filePath);
            convertedFile = Convert.ToBase64String(buffer);
   
            return convertedFile;           
        }
    }
