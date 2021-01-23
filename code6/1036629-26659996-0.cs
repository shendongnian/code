    var contacts = await Task.WhenAll(contactList.Select(
        async c => new ContactViewModel
        {
            phones = (await ContactBLL.GetContactPhones(c.ContactID)).ToList(),
            firstName = c.FirstName, 
            lastName = c.LastName
        }));
