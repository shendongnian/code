    public class MainViewModel
    {
        public List<AddCompToEventClass> Events { get; set; }
    }
    public class AddCompToEventClass
    {
        public int CompeditorID { get; set; }
        public int Event_CompID { get; set; }
        public string EventName { get; set; }
    }
