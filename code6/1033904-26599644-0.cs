    using System.Linq;
    using Microsoft.Phone.Tasks;
    using Microsoft.Phone.UserData;
    // create the phone number chooser
    PhoneNumberChooserTask phoneNumberChooserTask;
    phoneNumberChooserTask = new PhoneNumberChooserTask();
    phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
    phoneNumberChooserTask.Show();
    
    // user has chose a contact from the list
    void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            // At this point, we know the Phone Number and Display Name only
            // so lets search for all Contacts that have the same Phone Number and Display Name
            // create the search, we are going to filter by Display Name and past the Phone Number as the third variable (state)            
            Contacts cons = new Contacts();
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
            cons.SearchAsync(e.DisplayName, FilterKind.DisplayName, e.PhoneNumber);
        }
    }
    // search is complete
    // lets use some LINQ and select out the matching data we want (magic.. I know)
    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        Contact fullcontact = null;
        // query
        var q = from contact in e.Results
                from pn in contact.PhoneNumbers
                where pn.PhoneNumber.Equals((string)e.State, StringComparison.InvariantCultureIgnoreCase)
                select contact;
        // loop through all the matches (should be 1, if any)
        foreach (Contact c in q)
        {
           // save the contact
           fullcontact = c;   
        }                 
       
        // at this point fullcontact should contain everything if not null
    }
