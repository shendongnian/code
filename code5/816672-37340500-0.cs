    //Serialization
    var config = new HttpConfiguration();
    config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
    return Request.CreateResponse(HttpStatusCode.OK, dto, config);
    //Deserialization
    var formatter = new JsonMediaTypeFormatter
    {
        SerializerSettings = { TypeNameHandling = TypeNameHandling.Auto }
    };
    response.Content.ReadAsAsync<CMLandingPage>(new [] { formatter }).Result;
