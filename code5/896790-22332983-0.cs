    public enum Status
    {
        Pending  = 0,
        Accepted = 1,
        Rejected = 2
    }
    
    public class MyEntity
    {
        public int    MyEntityID { get; set; }
        public Status Status     { get; set; }
    }
    public enum Language
    {
        Language1 = 0,
        Language2 = 1
    }
    public class StatusTranslation
    {
        public int      StatusTranslationID { get; set; }
        public Language Language            { get; set; }
        public Status   Status              { get; set; }
        public string   Name                { get; set; }
    }
