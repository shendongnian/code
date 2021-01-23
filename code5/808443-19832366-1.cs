    var jobs = getJobs();    
    var contractResolver = new CustomContractResolver(new[]{ "Property1", "Property2" });
     
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(jobs, Newtonsoft.Json.Formatting.Indented,
        new Newtonsoft.Json.JsonSerializerSettings { ContractResolver = contractResolver });
