     public HttpResponseMessage<T> DoMyWork<T>(T obj)
     {
       ....
       var response = client.GetAsync(uri);
       return response.Content.ReadAsAsync<T>();
     }
