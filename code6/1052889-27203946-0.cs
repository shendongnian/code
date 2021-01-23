    public class Item
    {
    
        private string firstName = "";
        private string secondName = "";
    
        [JsonProperty("First Name")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
    
        [JsonProperty("Second Name")]
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
    }
