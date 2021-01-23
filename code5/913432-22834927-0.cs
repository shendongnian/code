    // Replace the following placeholder values with the target SharePoint site and
    // target user.
    const string serverUrl = "http://serverName/";  
    const string targetUser = "domainName\\userName";  
    // Connect to the client context.
    ClientContext clientContext = new ClientContext(serverUrl);
    // Get the PeopleManager object and then get the target user's properties.
    PeopleManager peopleManager = new PeopleManager(clientContext);
    PersonProperties personProperties = peopleManager.GetPropertiesFor(targetUser);
    // Load the request and run it on the server.
    // This example requests only the AccountName and UserProfileProperties
    // properties of the personProperties object.
    clientContext.Load(personProperties, p => p.AccountName, p => p.UserProfileProperties);
    clientContext.ExecuteQuery();
    foreach (var property in personProperties.UserProfileProperties)
    {
         Console.WriteLine(string.Format("{0}: {1}", 
             property.Key.ToString(), property.Value.ToString()));
    }
