    public class Contact
    {
    public string id { get; set; }
    public string phone { get; set; }
     }
     public class RootObject
    {
    public string sourceid { get; set; }
    public List<Contact> contacts { get; set; }
    }
