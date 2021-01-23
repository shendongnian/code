    public class EventResponseList
    {
        public string Event_Id { get; set; }
        public string Status_Code { get; set; }
        public DateTime Event_time { get; set; }
    }
    
    public class RootObjectEventResponseList
    {
        public List<EventResponseList> eventResponseList { get; set; }
    }
