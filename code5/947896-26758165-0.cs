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
        //Do something with the results.
        MessageBox.Show(e.Results.Count().ToString());
    }
    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        try
        {
            //Bind the results to the user interface.
            ContactResultsData.DataContext = e.Results;
        }
        catch (System.Exception)
        {
            //No results
        }
    
        if (ContactResultsData.Items.Any())
        {
            ContactResultsLabel.Text = "results";
        }
        else
        {
            ContactResultsLabel.Text = "no results";
        }
    }
