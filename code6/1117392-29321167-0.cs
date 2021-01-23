    public async Task<string> getJson(Uri url)
    {        
        bool error = false;
        if (NetworkInterface.GetIsNetworkAvailable())
        {         
           try
           {
               HttpClient client = new HttpClient();
               string jsonString = await client.GetStringAsync(url);
               return jsonString;
           }
           catch(Exception) // a more specific exception would be better
           {
               error = true;
           }
        }
        else
        {
            error = true;     
        }
        if (error)
        {
            await new MessageDialog("No internet connection is avaliable. Please check it !").ShowAsync();
            return "";
        }
    }
