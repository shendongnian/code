    try
    {
        this.client.ExecuteAsync<Answer>(request, response =>
            {
                if (response != null && response.ResponseStatus == ResponseStatus.Completed)
                    callback(response.Data);
                else
                {
                   // add logic here to handle bad case
                }
            });
    }
    catch (WebException ex) {...}
