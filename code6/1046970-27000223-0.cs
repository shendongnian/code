    public class Rootobject
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string summary { get; set; }
        public DateTime updated { get; set; }
        public string timeZone { get; set; }
        public string accessRole { get; set; }
        public object[] defaultReminders { get; set; }
        public string nextSyncToken { get; set; }
        public Item[] items { get; set; }
    }
    public class Item
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string htmlLink { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string summary { get; set; }
        public Creator creator { get; set; }
        public Organizer organizer { get; set; }
        public Start start { get; set; }
        public End end { get; set; }
        public string iCalUID { get; set; }
        public int sequence { get; set; }
    }
    public class Creator
    {
        public string email { get; set; }
        public string displayName { get; set; }
        public bool self { get; set; }
    }
    public class Organizer
    {
        public string email { get; set; }
        public string displayName { get; set; }
        public bool self { get; set; }
    }
    public class Start
    {
        public DateTime dateTime { get; set; }
    }
    public class End
    {
        public DateTime dateTime { get; set; }
    }
