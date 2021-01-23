    public object GetDynamicParameters()
    {
        var houseList = new List<string> { "Stark", "Lannister", "Tully" };
        var attributes = new Collection<Attribute>
        {
            new ParameterAttribute { HelpMessage = "Enter a house name" },
            new ValidateSetAttribute(houseList.ToArray()),
        };
        var runtimeParameters = new RuntimeDefinedParameterDictionary
        {
            {"House", new RuntimeDefinedParameter("House", typeof (string), attributes)}
        };
        var selectedHouse = this.GetUnboundValue<string>("House");
        //... add parameters dependant on value of selectedHouse
        return runtimeParameters;
    }
