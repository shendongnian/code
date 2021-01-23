        Uri url = new Uri("https://test.firebaseio.com/...");
        var request = new HttpClient();
        request.DefaultRequestHeaders.Accept.Clear();
        request.DefaultRequestHeaders.Accept.Add(new Windows.Web.Http.Headers.HttpMediaTypeWithQualityHeaderValue("text/event-stream"));
            
        Task task = request.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).AsTask().ContinueWith(t =>
             {
                 t.Result.Content.ReadAsInputStreamAsync().AsTask().ContinueWith(async t1 =>
                    {
                        IInputStream istr = await t1;
                        Stream s = istr.AsStreamForRead();
                        byte[] buffer = new byte[1024 * 8];
                        int bytesRead = await s.ReadAsync(buffer, 0, buffer.Length);
                        string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        System.Diagnostics.Debug.WriteLine(content);
                    });
            });
