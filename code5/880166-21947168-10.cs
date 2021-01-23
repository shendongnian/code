    using (var db = new Context())
    {
        var json = JsonConvert.SerializeObject(db.Accounts.FirstOrDefault(), Formatting.Indented, 
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        Console.WriteLine(json);
    }
