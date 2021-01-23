    {
    	public string Id { get; set; }
    
    	public string StringTest { get; set; }
    
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    	public DateTime DateTest { get; set; }
    }
