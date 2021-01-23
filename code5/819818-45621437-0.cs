        actionContext.Response = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.Forbidden,
            Content = new StringContent(unauthorizedMessage)
        };
