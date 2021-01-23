    public class Data
    {
        [JsonProperty("supplier")]
        [JsonConverter(typeof(SupplierDataConverter))]
        public SupplierData Supplier { get; set; }
    }
