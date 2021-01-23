    List<CustomContact> listOfContacts = new List<CustomContact>();
    foreach (var c in e.Results)
    {
        CustomContact contact  = new CustomContact();
        contact.DisplayName = c.DisplayName;
        var number = c.PhoneNumbers.FirstOrDefault(); //change this to whatever number you want
        if (number != null)
            contact.Number = number.PhoneNumber;
        else
            contact.Number = "";
        listOfContacts.Add(contact);
    }
    ContactResultsData.DataContext = listOfContacts;
