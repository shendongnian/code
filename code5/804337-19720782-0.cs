    public class ContactPhone
    {
    public int ID {get; set);
    public int ContactID {get; set;};
    public int PhoneTypeID {get; set;};
    }
    // key is ID, value is the ContactPhone object
    Dictionary<int, ContactPhone> contacts = new Dictionary<int, ContactPhone>();
    
    // create a new ContactPhone object
    ContactPhone contact = new ContactPhone(1, 1, 1); 
    // put the ContactPhone object into the dictionary with ID as the key
    contacts.Add(1,contact);  
