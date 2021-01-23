    // You can drop these two as we aren't using the modelbinding
    // [ModelBinder(typeof(JsonModelBinder))] 
    // [DataContract]
    public class JsonFileContentInputs
    {
        [JsonProperty(PropertyName = "baseDetails")]
        public Dictionary<string, string> BaseDetails { get; set; }  
    }
