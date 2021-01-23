    [JsonProperty(PropertyName = "TargetName")]
    private List<SomeClass> _SomeClassList { get; set; }
    public IReadOnlyList<SomeClass> SomeClassList
    {
        get
        {
            return this._SomeClassList.AsReadOnly();
        }
    }
