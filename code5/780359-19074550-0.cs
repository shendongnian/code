    var namesInProperties = new HashSet<string>();
    foreach (Property p in PropertyList)
    {
        namesInProperties.Add(p.PropMgr);
        namesInProperties.Add(p.Rep);
    }
    IEnumerable<Contact> matchingContacts = ContactsList.Where(c => namesInProperties.Contains(c.fullName));
