        void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            IEnumerable<Contact> contacts = e.Results; //Here your result
            string everynames = String.Empty;
            foreach (var item in contacts)
            {
                //We can get attributes from each item
                everynames += item.DisplayName + ";" //Get name
                    + (item.EmailAddresses.Count() > 0 ? (item.EmailAddresses.FirstOrDefault()).EmailAddress : "") + ";" //Check if contact has an email. If so, display it. He can be more than one !
                    + (item.PhoneNumbers.Count() > 0 ? (item.PhoneNumbers.FirstOrDefault()).PhoneNumber : "") + ";" //Check if contact has a phonenumber. If so, display it. He can be more than one !
                    + Environment.NewLine;
            }
            MessageBox.Show(everynames);
        }
