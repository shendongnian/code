    internal static async Task<string> WebClientAsync(string URI, NetworkCredential Creds = null, Dictionary.FantasySite Site = Dictionary.FantasySite.Other)
    {
        // If (Creds == null) removed, you must return a task or throw an exception.
        //attempt to get the web page
        HttpClient client = new HttpClient(); //create client
        HttpResponseMessage response = await client.GetAsync(URI);  //get response
        response.EnsureSuccessStatusCode(); //ensure the response is good (or throw Exception)
        return await response.Content.ReadAsStringAsync();  //return the string back
    }
    internal static async Task<string> WebClientRetryAsync(string URI, NetworkCredential Creds = null, Dictionary.FantasySite Site = Dictionary.FantasySite.Other)
    {
        // assumes you have .NET 4.5, otherwise save exception.
        // uses System.Runtime.ExceptionServices;
        ExceptionDispatchInfo exceptionDispatchInfo = null; 
        for (int i = 0; i < Dictionary.WEB_PAGE_ATTEMPTS; i++)  //Attempt to get the webpage x times
        {
            System.Diagnostics.Debug.Print(string.Format("WebClientRetryAsync attempt {0} for {1}", i + 1, URI));
            try
            {
                var webPage = await WebClientAsync(URI, Creds, Site);
                return webPage;
            }
            catch (Exception ex)
            {
                // save exception so it can be rethrown.
                exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
                if (i < Dictionary.WEB_PAGE_ATTEMPTS - 1)
                    //wait some time before retrying just in case we are too busy
                    //Start wait at 0 for first time and multiply with each successive failure to slow down process by multiplying by i squared
                    Thread.Sleep(Wait.Next(i * i * Dictionary.RETRY_WAIT_MS));
            }
        }
        Debug.Assert(exceptionDispatchInfo != null); // shouldn't be null if we get here.
        exceptionDispatchInfo.Throw();
    }
