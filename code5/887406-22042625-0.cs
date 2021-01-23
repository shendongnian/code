    var resolver = new MyUserBasedResolver(userObject);
    JsonConvert.SerializeObject(
            product,
            Formatting.Indented,
            new JsonSerializerSettings { ContractResolver = resolver }
            );
