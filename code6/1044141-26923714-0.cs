    [DataContract(Name = "frequentQueryRequest", Namespace = "")]
    public class FrequentQueryRequest
    {
    	[DataMember(Name = "fields", Order = 1, EmitDefaultValue = false)]
    	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]		
    	public string[] Fields  { get; set; }
    
    	[DataMember(Name = "dateRange", Order = 2, EmitDefaultValue = false)]
    	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    	public DateRange Range  { get; set; }	
    }
    
    [DataContract(Name = "dateRange", Namespace = "")]
    public class DateRange
    {
    	[DataMember(Name = "from", Order = 3, EmitDefaultValue = false)]
    	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    	public DateTime? From { get; set; }
    
    	[DataMember(Name = "to", Order = 4, EmitDefaultValue = false)]
    	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    	public DateTime? To { get; set; }
    }
	
