    public HttpResponseMessage Post(bool asynch, [FromBody]DatedValue value)
    {
        Guid key = Guid.NewGuid();
    
        Task.Factory.StartNew(() =>
        {
            queue.Add(key, 0);
            DatedValue justCreated = Insert(value);
            queue[key] = justCreated.Id;
        });
    
        HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Accepted);
        message.Headers.Location = new Uri("/ValueQueue/" + key);
        return message;
    }
