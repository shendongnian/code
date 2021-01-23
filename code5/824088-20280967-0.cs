    public Task<Tuple<HttpResponseMessage,Stream>> Get(string id, string path)
    {            
        //do stuff           
        return Task.Factory.StartNew(() =>
        {
            var stream = new MemoryStream();
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = GetPngBitmap(stream)
                };
                response.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return Tuple.Create(response, stream);
            }
        })
        .ContinueWith(t => t.Result.Item2.Close());
    }
