    using (var client = new HttpClient())
    {
	    var request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://www.example.com"));
		
        try
        {
            // Http-errors are returned in the response, and no exception is thrown.
            HttpResponseMessage response = await client.SendRequestAsync(request);
        }
        catch (Exception ex)
        {
            WebErrorStatus error = WebError.GetStatus(ex.HResult);
            // For example, if your device could not connect to the internet at all,
			// the error would be WebErrorStatus.HostNameNotResolved.
        }
    }
