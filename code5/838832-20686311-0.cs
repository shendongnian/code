    var contact = ac.Contacts.SingleOrDefault(c => c.ContractType.Contains("string"));
    if (contact != null)
    {
        var userContact = contact.UserContact;
    }
    else
    {
        // handle not found situation
    }
