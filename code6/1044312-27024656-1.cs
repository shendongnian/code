        using (ContactLINQDataContext context = new ContactLINQDataContext("Data Source=WORK-PC;Initial Catalog=Steve Harvey Team;Integrated Security=True"))
        {
            Contact contact = context.Contacts.SingleOrDefault(x => x.ContactID == contactID);
            Contact spouse = context.Contacts.SingleOrDefault(x => x.ContactID == contact.Spouse);
            Property property = context.Properties.SingleOrDefault(x => x.PropertyID == contact.Address);
            firstNameBox1.Text = contact.FirstName;
            lastNameBox1.Text = contact.LastName;
            firstNameBox2.Text = spouse.FirstName;
            lastNameBox2.Text = spouse.LastName;
            streetBox.Text = property.Street;
            cityBox.Text = property.City;
            stateBox.Text = property.State;
            zipBox.Text = property.ZIP;
            phoneBox.Text = contact.Phone;
            altPhoneBox.Text = spouse.Phone;
            emailBox.Text = contact.Email;
        }
