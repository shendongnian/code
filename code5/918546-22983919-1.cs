    Account acc = new Account();
    acc.Name = "Ram"; // this values got inserted
    acc.Age = "22"; // this values got inserted
    acc.LookupFieldId = new EntityReference("contact", contactId); // if lookupfieldid is pointing to contact entity
    service.Create(acc); // to create account
