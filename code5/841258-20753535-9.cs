    string[] contact = null;
    
    for (int i = 0; i < sContacts.Length; i++)
    {
        if (sContacts[i, 0].Equals(name, StringComparison.InvariantCultureIgnoreCase))
        {
            contact = new string[2];
            contact[0] = sContacts[i, 0];
            contact[1] = sContacts[i, 1];
            break;
        }
    }
