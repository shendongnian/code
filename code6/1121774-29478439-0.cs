    public class HelloWorldModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [Computed]
        [ScriptIgnore]
        [JsonIgnore]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
