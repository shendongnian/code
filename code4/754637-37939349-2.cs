    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
       foreach (var item in e.Results) {
          var contact = new PhoneContact();
          contact.Name = item.DisplayName;
          foreach (var pn in item.PhoneNumbers)
              contact.Number = string.IsNullOrEmpty(contact.Number) ? pn.PhoneNumber : (contact.Number + " , " + pn.PhoneNumber);
          foreach (var ea in item.EmailAddresses)
               contact.Email = string.IsNullOrEmpty(contact.Email) ? ea.EmailAddress : (contact.Email + " , " + ea.EmailAddress);
          phoneContact.Add(contact);
       }  
    }
    
