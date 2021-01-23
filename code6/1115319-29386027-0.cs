        class Record{
        int Id { get; set; }
        int TypeOfDetails { get; set; } // int enum Type1, Type2
        string JsonDetails { get; set; } //string with json content
        string Attribute1 { get; set; }
        string Atribute2 { get; set; }
        ...
        [NotMapped]
        public JObject Details { get; set; }
        
        public void PopulateDetails()
    	{
    		Details = JObject.Parse(JsonDetails);
    	}    
    }
