    public class Note
    {
        public string noteId { get; set; }
        public string studentId { get; set; }
        public string advisorId { get; set; }
        public string dateCreated { get; set; }
        public string studentStatus { get; set; }
        public string noteBody { get; set; }
        public string edited { get; set; }
        public string dateEdited { get; set; }
        public string privateNote { get; set; }
        public string removed { get; set; }
        public string removedDate { get; set; }
        public string displayDate { get; set; }
        public string noteCreatedWithReminder { get; set; }
        public string noteCreatedWithStatusChange { get; set; }
    }
    
    public class Response
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Note> notes { get; set; }
    }
