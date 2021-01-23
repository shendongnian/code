        ContactLINQDataContext context = new ContactLINQDataContext("Data Source=WORK-PC;Initial Catalog=Steve Harvey Team;Integrated Security=True");
        var editContact = (from Contacts in context.Contacts
                           where Contacts.ContactID == contactID
                           select Contacts
                           }).First();
        editContact.FirstName = firstNameBox1.Text;
