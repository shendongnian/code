    static async Task<byte[]> GetByteArrayTaskProvider(Task<HttpResponseMessage> httpOperation, CancellationToken token, IProgress<int> progressCallback)
    {
        int offset = 0;
        int streamLength = 0;
        var result = new List<byte>();
    
        var responseBuffer = new byte[500];
    
        // Execute the http request and get the initial response
        // NOTE: We might receive a network error here
        var httpInitialResponse = await httpOperation;
        var totalValueAsString = httpInitialResponse.Content.Headers.SingleOrDefault(h => h.Key.Equals("Content-Length"))?.Value?.First());
        int? totalValue = totalValueAsString != null ? int.Parse(totalValueAsString) : null;
               
        using (var responseStream = await httpInitialResponse.Content.ReadAsStreamAsync())
        {
           int read;
           do
           {
               if (token.IsCancellationRequested)
               {
                  token.ThrowIfCancellationRequested();
               }
    
               read = await responseStream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
               result.AddRange(responseBuffer);
    
               offset += read;
               if (totalSize.HasValue)
               {
                  progressCallback.Report(offset * 100 / totalSize);
               }
               //for else you could send back the offset, but the code would become to complex in this method and outside of it. The logic for "supports progress reporting" should be somewhere else, to keep methods simple and non-multi-purpose (I would create a method for with bytes progress and another for percentage progress)
           } while (read != 0);
        }
        return result.ToArray();
    }
