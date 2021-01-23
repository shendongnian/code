    [JsonConverter(typeof(YearInfoConverter))]
    class YearInfo
    {
        public YearInfo(int year)
        {
            Year = year;
        }
    
        [JsonIgnore]
        public int Year { get; set; }
    
        public List<MonthInfo> Months { get; set; }
    }
    class MonthInfo
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    
    
