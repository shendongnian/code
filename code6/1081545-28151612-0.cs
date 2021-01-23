     // the form is a login form
    public async Task PreObtainData(ref MonavisaRequestForm request, string dateAndTime, string fileDateAndTime)
    {
        if (!initialized)
            Initialize();
        try
        {
            if (!request.webclient.IsBusy && requestQueue.Count == 0)
            {
                
                ...
                await request.webclient.DownloadFileTaskAsync(uri, @"Nioo Graph Data " + fileDateAndTime + ".xml");
            }
            else if (!request.webclient.IsBusy && requestQueue.Count > 0)
            {
                ...
                await requestQueue.Peek().webclient.DownloadFileTaskAsync(uri, @"Nioo Graph Data " + fileDateAndTime + ".xml");
                requestQueue.Dequeue();
            }
            else
            {
                requestQueue.Enqueue(request);
            }
        }
        catch (System.Net.WebException ex)
        {
            if (ex.Status != System.Net.WebExceptionStatus.ProtocolError)
            {
                throw;
            }
        }
    }
