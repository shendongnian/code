    void GetContact()
    {
        cons = new Contacts();
        //Identify the method that runs after the asynchronous search completes.
        cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(ContactsSearchCompleted);
        //Start the asynchronous search.
        cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
    }
    private void ContactsSearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        cons.SearchCompleted -= ContactsSearchCompleted;
        //e.Results should be the list of contact, since there's no filter applyed in the search you shoul have all contact here
    }
