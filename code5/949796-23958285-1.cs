    public HttpResponseMessage Get()
    {
      var query = AsyncDocumentSession.Query<Foo, FooIndex>();
      HttpResponseMessage response = Request.CreateResponse();
      response.Content = new PushStreamContent(
          async (stream, content, context) =>
          {
            using (stream)
            using (var enumerator = await AsyncDocumentSession.Advanced.StreamAsync(query))
            {
              while (await enumerator.MoveNextAsync())
              {
                // TODO: adjust encoding as necessary.
                var serialized = JsonConvert.SerializeObject(enumerator.CurrentDocument);
                var data = UTF8Encoding.UTF8.GetBytes(serialized);
                var countPrefix = BitConverter.GetBytes(data.Length);
                await stream.WriteAsync(countPrefix, 0, countPrefix.Length);
                await stream.WriteAsync(data, 0, data.Length);
              }
            }
          });
      return response;
    }
