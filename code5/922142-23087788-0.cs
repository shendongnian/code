    if (user == null || user2  == null)
    {
        return new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent(string.Format("access denied")),
        };
    }
    //...
