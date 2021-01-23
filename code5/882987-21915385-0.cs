    public class Person 
    {
        public string FirstName { get; set; }
        
        [JsonIgnore]
        public DateTime Birthday { get; set; }
        
        public string Birthdate 
        {
            get { return Birthday.Date.ToString(); }   
            set {}     
        }
    }
