    [HttpGet]
    public MyObject MyMethod()
    {
        try
        {
            return mysService.GetMyObject()
        }
        catch (SomeException)
        {
            throw new HttpResponseException(
                new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content =
                            new StringContent("Something went wrong.")
                    });
        }
    }
