    public class Record
    {
        public int Id { get; set;} 
        public string Name {get; set;}
    
        public DateTime Date {get; set;}
    
        public bool IsRepeatable {get; set;}
            
        public int RepetitionType {get; set;}
        public DateTime? RepeatingEndDate { get; set; }
    }
