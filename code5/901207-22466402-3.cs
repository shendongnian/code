    Account account = new Account
    {
        Id = "100",
        CreatedById = "2",
        CreatedDate = new DateTime(2014, 3, 12, 14, 52, 18, DateTimeKind.Utc),
        LastModifiedById = "3",
        LastModifiedDate = new DateTime(2014, 3, 17, 16, 3, 34, DateTimeKind.Utc),
        AccountNumber = "1234567",
        ParentId = "99"
    };
    JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        ContractResolver = new CustomResolver(),
        Formatting = Formatting.Indented
    };
    string json = JsonConvert.SerializeObject(account, settings);
    Console.WriteLine(json);
