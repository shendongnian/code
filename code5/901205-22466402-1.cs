    ObjectBase obj = new ObjectBase
    {
        Id = "foo",
        CreatedById = "bar",
        CreatedDate = new DateTime(2014, 3, 12, 14, 52, 18, DateTimeKind.Utc),
        LastModifiedById = "baz",
        LastModifiedDate = new DateTime(2014, 3, 17, 16, 3, 34, DateTimeKind.Utc)
    };
    JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        ContractResolver = new CustomResolver(),
        Formatting = Formatting.Indented
    };
    string json = JsonConvert.SerializeObject(obj, settings);
    Console.WriteLine(json);
