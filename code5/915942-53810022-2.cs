    var settings = new JsonSerializerSettings
    {
        Converters = { new StringEnumConverter(new KebabCaseNamingStrategy()) },
    };
    var json = JsonConvert.SerializeObject(MyEnum.SomeEnumValue, settings);
    Assert.IsTrue(json == "\"some-enum-value\""); // Passes successfully
