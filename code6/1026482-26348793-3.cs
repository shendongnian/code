    private async Task mymethodAsync(int[] myIds)
    {
        var uri = new Uri(string.Format(UriPath, string.Format(MyPath)));
        var client = GetHttpClient(uri);
  
        var postModel = new PostModel { ... };
        if (client != null)
        {
            try 
            {
                var response = await client.PostAsJsonAsync(uri, postModel);
                if (response.IsSuccessStatusCode)
                {
                    //doSomething
                }
            }
            catch (OperationCanceledException oce) 
            {
                // because timeouts are still possible
            }
            catch (Exception exc) {
                // Because other things can still go wrong too (HTTP 500, parsing errors)
            }
        }
    }
