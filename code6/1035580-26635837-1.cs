    var settings = new JsonSerializerSettings();
    settings.ContractResolver = new GenericPropertyContractResolver(typeof(Response<>));
    
    string serialized = JsonConvert.SerializeObject(new Response<Thang> 
    { 
        Data = new Thang { Thing = "Hey" }
    }, settings);
