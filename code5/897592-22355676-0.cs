    Dictionary<string, object> collection = new Dictionary<string, object>()
        {
          {"First", new Person(<add FirstName as constructor>)},
          {"Second", new Person(<add LastName as constructor>)},
          
        };
    string json = JsonConvert.SerializeObject(collection, Formatting.Indented, new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All,
        TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
      });
