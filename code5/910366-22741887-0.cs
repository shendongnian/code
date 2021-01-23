    public class Group
    {
     [Index("GroupIdIndex", 1)]
     public int GroupID { get; set; }
     public string Name { get; set; }
     public virtual ICollection<Contact> Contacts { get; set; }
    }
    public class Contact
    {
     [Index("ContactIdIndex", 1)]
     public int ContactID { get; set; }
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public virtual ICollection<Group> Groups { get; set; }
    }
