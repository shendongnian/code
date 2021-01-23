    internal class Test
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
        [JsonProperty("columns")]
        public Column[] Columns { get; set; }
        [JsonProperty("rows")]
        public Row[] Rows { get; set; }
    }
    internal class Metadata
    {    
        [JsonProperty("columnGrouping")]
        public string[] ColumnGrouping { get; set; }
    
        [JsonProperty("rowGrouping")]
        public object[] RowGrouping { get; set; }
    }
    
    internal class Area
    {   
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    
        [JsonProperty("label")]
        public string Label { get; set; }
    
        [JsonProperty("altLabel")]
        public string AltLabel { get; set; }
    
        [JsonProperty("isSummary")]
        public bool IsSummary { get; set; }
    }
    
    internal class MetricType
    {   
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    
        [JsonProperty("label")]
        public string Label { get; set; }
    
        [JsonProperty("altLabel")]
        public string AltLabel { get; set; }
    
        [JsonProperty("isSummary")]
        public bool IsSummary { get; set; }
    }
    
    internal class Period
    {   
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    
        [JsonProperty("label")]
        public string Label { get; set; }
    
        [JsonProperty("altLabel")]
        public string AltLabel { get; set; }
    
        [JsonProperty("isSummary")]
        public bool IsSummary { get; set; }
    }
    
    internal class ValueType
    {   
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    
        [JsonProperty("label")]
        public string Label { get; set; }
    
        [JsonProperty("isSummary")]
        public bool IsSummary { get; set; }
    }
    
    internal class Column
    {  
        [JsonProperty("area")]
        public Area Area { get; set; }
    
        [JsonProperty("metricType")]
        public MetricType MetricType { get; set; }
    
        [JsonProperty("period")]
        public Period Period { get; set; }
    
        [JsonProperty("valueType")]
        public ValueType ValueType { get; set; }
    }
    
    internal class Value
    { 
        [JsonProperty("source")]
        public double Source { get; set; }
    
        [JsonProperty("value")]
        public double Value { get; set; }
    
        [JsonProperty("formatted")]
        public string Formatted { get; set; }
    
        [JsonProperty("format")]
        public string Format { get; set; }
    
        [JsonProperty("publicationStatus")]
        public string PublicationStatus { get; set; }
    }
    
    internal class Row
    { 
        [JsonProperty("values")]
        public Value[] Values { get; set; }
    }
