    class ReturnObjectA 
    {
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime ReturnDate { get;set;}
    }
