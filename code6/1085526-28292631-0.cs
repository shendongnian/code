    public class Field
    {
        public int id { get; set; }
        public string type { get; set; }
        public object value { get; set; }
        public string editedBy { get; set; }
        public List<object> flags { get; set; }
        public List<object> categories { get; set; }
        public string updated { get; set; }
        public string created { get; set; }
        public string uri { get; set; }
        public bool? isConnection { get; set; }
    }
    
    public class Contact
    {
        public bool isConnection { get; set; }
        public int id { get; set; }
        public List<Field> fields { get; set; }
        public List<object> categories { get; set; }
        public int error { get; set; }
        public int restoredId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string uri { get; set; }
    }
    
    public class Contacts
    {
        public List<Contact> contact { get; set; }
        public int count { get; set; }
        public int start { get; set; }
        public int total { get; set; }
        public string uri { get; set; }
        public bool cache { get; set; }
    }
    
    public class RootObject
    {
        public Contacts contacts { get; set; }
    }
