    public static async Task CopyToAsync(
    	System.Net.Http.HttpClient httpClient, 
    	System.Net.Http.HttpContent httpContent,
    	Stream stream, CancellationToken ct)
    {
    	using (ct.Register(() => httpClient.CancelPendingRequests()))
    	{
    		await httpContent.CopyToAsync(stream);
    	}
    }
