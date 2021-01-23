    [JsonProperty("name")]
    public string Name
    {
        get { return this.GetAttributeValue<string>("name"); }
        set { this.SetAttributeValue<string>("name", value); }
    }
