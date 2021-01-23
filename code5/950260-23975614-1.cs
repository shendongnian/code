    var person = new Person
                {
                    FirstName = "John",
                    IsEmployed = false
                };
    
    var json = JsonConvert.SerializeObject(person, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
