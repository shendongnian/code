    string json = JsonConvert.SerializeObject( histogram, Formatting.Indented, new   JsonSerializerSettings
           {
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
          });
    
    return Request.CreateResponse(HttpStatusCode.OK, json);
