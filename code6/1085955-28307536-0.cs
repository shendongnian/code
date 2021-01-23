    public class Company
    {
    
        public int Id {get;set;}
    
        public string Name {get;set;}
    
	    [NotMapped]
        public List<DateTime> Times {get;set;}
        
		[Column("Times")]
        public string TimesSerialized
        {
            get
            {
                return JsonConvert.SerializeObject(Times);
            }
            set
            {
                Times = string.IsNullOrEmpty(value)
                        ? new List<DateTime>()
                        : JsonConvert.DeserializeObject<List<DateTime>>(value);
            }
        }
    }
    
