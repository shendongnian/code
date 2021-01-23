    var ignorableSerializerContractResolver = new IgnorableSerializerContractResolver()
       .Ignore<MyBaseClass>(x => x.MyProperty);
    var formatter = new JsonMediaTypeFormatter
    {
        SerializerSettings =
        {
            ContractResolver = ignorableSerializerContractResolver
        }
    };
    
    return Request.CreateResponse(HttpStatusCode.OK, model, formatter);
