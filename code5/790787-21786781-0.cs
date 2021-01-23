    try
    {       
        // if (something bad happens in my code)
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("custom error message here") });
    }
    catch (HttpResponseException x)
    {
        // just rethrows exception to API caller
        throw;
    }
    catch (Exception x)
    {
        // casts and formats general exceptions HttpResponseException so that it behaves like true Http error response with general status code 500 InternalServerError
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(x.Message) });
    }
