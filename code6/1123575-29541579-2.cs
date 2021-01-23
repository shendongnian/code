    [Table("Countries")]
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
    
    
    [Table("States")]
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string CountryCode { get; set; }
    }
