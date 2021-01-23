    public class Contact
    {
    public int ID { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int ContactTypeID { get; set; }
    
    public Contact(Info info, Contact contact)
    {
       ID = info.ID;
       LastName = string.IsNullOrEmpty(info.LastName) ? contact.LastName : info.LastName;
    }
    }
