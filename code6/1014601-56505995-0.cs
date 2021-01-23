    var contractResolver = new DefaultContractResolver();
    contractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;
    Engine r = JsonConvert.DeserializeObject<Engine>(json), new JsonSerializerSettings
                {
                    ContractResolver = contractResolver
                });
