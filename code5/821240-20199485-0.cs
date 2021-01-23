    if (Contact.Qualifier1 != null || Contact.Number1 != null)
        list.Add(new ContactNumber
            { Qualifier = Contact.Qualifier1, Number = Contact.Number1 });
    if (Contact.Qualifier2 != null || Contact.Number2 != null)
        list.Add(new ContactNumber
            { Qualifier = Contact.Qualifier2, Number = Contact.Number2 });
    if (Contact.Qualifier3 != null || Contact.Number3 != null)
        list.Add(new ContactNumber
            { Qualifier = Contact.Qualifier3, Number = Contact.Number3 });
