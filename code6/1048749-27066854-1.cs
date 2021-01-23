    public static IEnumerable<ContactModel> SelectContacts(
            List<ContactModel> contacts, string[] targetGroups)
    {
        return from contact in contacts
               where targetGroups.Any(targetGroup => 
                     contact.ContactGroups.Contains(targetGroup))
               select contact;
    }
    
