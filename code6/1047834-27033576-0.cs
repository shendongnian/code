    public async Task<RootObject> GetItems(string feedUrl)
    {
            try
            {
                using (WebClient webclient = new WebClient()) 
                {
                     var json =  await webclient.DownloadStringTaskAsync(feedUrl);
                     var model = JsonConvert.DeserializeObject<RootObject>(json);
                     return model;
                }
            }
            catch(Exception ex)
            {
                    Console.WriteLine(ex.Message);
                    return null;
            }
    }
        
