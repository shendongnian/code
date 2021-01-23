    internal class SampleResponse1
    {
        [JsonProperty("ParentClause")]
        public object ParentClause { get; set; }
        [JsonProperty("FilterClauseType")]
        public int FilterClauseType { get; set; }
        [JsonProperty("FilterClauses")]
        public FilterClaus[] FilterClauses { get; set; }
        [JsonProperty("ComparisonType")]
        public object ComparisonType { get; set; }
        [JsonProperty("FieldStaticName")]
        public object FieldStaticName { get; set; }
        [JsonProperty("Value")]
        public object Value { get; set; }
        [JsonProperty("FieldValueType")]
        public object FieldValueType { get; set; }
    }
    internal class FilterClaus
    {
        [JsonProperty("FilterClauseType")]
        public int FilterClauseType { get; set; }
        [JsonProperty("FilterClauses")]
        public object[] FilterClauses { get; set; }
        [JsonProperty("ComparisonType")]
        public int ComparisonType { get; set; }
        [JsonProperty("FieldStaticName")]
        public string FieldStaticName { get; set; }
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("FieldValueType")]
        public int FieldValueType { get; set; }
    }
