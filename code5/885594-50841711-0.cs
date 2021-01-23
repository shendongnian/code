    var cycles = cycleSource.AllCycles();
    
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
    
    var vm = new JArray();
    
    foreach (var cycle in cycles)
    {
        var cycleJson = JObject.FromObject(cycle);
        // extend cycleJson ......
        vm.Add(cycleJson);
    }
    
    return vm;
