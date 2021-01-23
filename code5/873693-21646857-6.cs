    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        IEnumerable<Contact> contacts = e.Results; //Here your result
        string everynames = String.Empty;
        foreach (var item in contacts)
        {
            //We can get attributes from each item
            everynames += item.DisplayName +  Environment.NewLine;
        }
        MessageBox.Show(everynames);
    }
