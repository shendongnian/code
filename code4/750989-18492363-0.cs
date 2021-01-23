    OAuth2Authenticator<NativeApplicationClient> auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
    
    //This will call your GetAuthorization method
    auth.LoadAccessToken()
    RequestSettings settings = new RequestSettings("appName", auth.State.AccessToken);
    ContactsRequest cRequest = new ContactsRequest(settings);
    
    // fetch contacts list
    Feed<Contact> feedContacts = cRequest.GetContacts();
    foreach (Contact gmailAddresses in feedContacts.Entries)
    {
            // Looping to read  email addresses
            foreach (EMail emailId in gmailAddresses.Emails)
            {
               lstContacts.Add(emailId.Address);
            }
    }
