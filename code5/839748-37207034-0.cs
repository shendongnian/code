    using Newtonsoft.Json;
    ....
    [NotMapped]
    public Dictionary<string, string> MetaData { get; set; } = new Dictionary<string, string>();
    /// <summary> <see cref="MetaData"/> for database persistence. </summary>
    [Obsolete("Only for Persistence by EntityFramework")]
    public string MetaDataJsonForDb
    {
        get
        {
            return MetaData == null || !MetaData.Any()
                       ? null
                       : JsonConvert.SerializeObject(MetaData);
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
               MetaData.Clear();
            else
               MetaData = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
        }
    }
