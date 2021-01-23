    public string AddContact(Contact contact)
    {
        if (contact != null)
        {
            db.Contacts.Add(contact);
            contact.Emails1.Add(new Email { Email1 = "email@email.com"})
            contact.Emails1.Add(new Email { Email1 = "email2@email.com"})
            contact.Phones1.Add(new Phone1 { PhoneNumber = "1234516123"})
            db.SaveChanges();
            return "Contact Added";
        }
        else
        {
                return "Invalid Record";
        }
    }
