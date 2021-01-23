     public async Task UploadImage(byte[] image, string url)
            {
                Stream stream = new System.IO.MemoryStream(image);
                HttpStreamContent streamContent = new HttpStreamContent(stream.AsInputStream());
    
                Uri resourceAddress = null;
                Uri.TryCreate(url.Trim(), UriKind.Absolute, out resourceAddress);
                Windows.Web.Http.HttpRequestMessage request = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, resourceAddress);
                request.Content = streamContent;
    
                var httpClient = new Windows.Web.Http.HttpClient();
                var cts = new CancellationTokenSource();
                Windows.Web.Http.HttpResponseMessage response = await httpClient.SendRequestAsync(request).AsTask(cts.Token);
            }
