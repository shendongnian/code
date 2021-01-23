                 public ClientTable ClientId { get; set; }
    	
           [ForeignKey("ClientId")]
    	   [JsonProperty(PropertyName = "ItemClientID")]
           public virtual ClientTable Client { get; set; }
      
    	   public string TypeTableId { get; set; }
           [ForeignKey("TypeTableId")]
    	   [JsonProperty(PropertyName = "ItemTypeID")]
           public virtual TypeTable TypeTable { get; set; }
