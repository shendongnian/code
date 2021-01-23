    private void ButtonContacts_Click(object sender, RoutedEventArgs e)
    {
        Contacts cons = new Contacts();
    
        //Identify the method that runs after the asynchronous search completes.
        cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
    
        //Start the asynchronous search.
        cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
    }
    
    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        /* Here use the e.Results to return an object of type QueryDataEnumerable<Microsoft.Phone.UserData.Contact> where you can enumerate through the contacts returned*/
    }
