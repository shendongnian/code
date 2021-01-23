    public class Events {
        public Events()
        {
            this.eventData = new List<EventData>();
        }
        public string ListID { get; set; } 
        public List<EventData> eventData { get; set; } 
    }
    public class EventData {
        public EventData()
        {
            this.CustomFields = new List<CustomFields>();
        }
        public DateTime Date { get; set; }
        public string OldEmailAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public List<CustomFields> CustomFields { get; set; }
    }
    public class CustomFields
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
