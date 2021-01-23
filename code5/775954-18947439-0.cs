    [WebMethod]
    [ScriptMethod]
    public List<Event> GetAllEvents()
    {
        List<Event> events = .......
        ..fill the list....
        return evetns;
    }
    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool allDay { get; set; }
    }
