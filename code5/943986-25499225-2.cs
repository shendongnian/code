    public MyContractClass
    {
    
        [JsonProperty("thisPropertyIsFine")]
        public string ThisPropertyIsFine { get; set; }
    
        [JsonProperty("thisPropertyFails")]
        public ClassDefinedInAnotherAssembly[] ThisPropertyFails { get; set; }
    }
