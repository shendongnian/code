    [IgnoreDataMember]
    public DateTime? UpdateDate { get; set; }
    
    [DataMember(Name = "UpdateDate")]
    private string UpdateDateString { get; set; }
    
    [OnSerializing]
    void OnSerializing(StreamingContext context)
    {
        if (this.UpdateDate == null)
    	this.UpdateDateString = "";
        else
    	this.UpdateDateString = this.UpdateDate.Value.ToString("MMM/dd/yyyy hh:mm", CultureInfo.InvariantCulture);
    }
    
    [OnDeserialized]
    void OnDeserializing(StreamingContext context)
    {
        if (this.UpdateDateString == null)
    	this.UpdateDate = null;
        else
    	this.UpdateDate = DateTime.ParseExact(this.UpdateDateString, "MMM/dd/yyyy hh:mm", CultureInfo.InvariantCulture);
    }
