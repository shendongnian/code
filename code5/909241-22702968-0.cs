    Dictionary<Guid, Client> clients = new Dictionary<Guid, Client>();
    
    // first read all the Client records.
    while (reader.Read())
    {
     Guid clientId = Guid.Parse(reader["Id"].ToString());
     Client tempClient = new Client();
     tempClient.Contacts = new List<Contact>();
     // construct the tempClient completely using all fields.
    
     clients.Add(clientId, tempClient);
    }
    
    // now move onto the address records.
    reader.nextResults();
    
    while (reader.Read())
    {
     Guid clientId = Guid.Parse(reader["ClientId"].ToString());
     clients[clientId].Address = new Address();
     // construct the clients[clientId].Address completely using all fields.
    }
    
    // now move onto the contact records.
    reader.nextResults();
    
    while (reader.Read())
    {
     Guid clientId = Guid.Parse(reader["ClientId"].ToString());
     Contact tempContact = new Contact();
     // construct the tempContact completely using all fields.
    
     clients[clientId].Contacts.Add(tempContact)
    }
    
    // at the end, the clients dictionary has all the Client objects linked with the right 
    // Address and Contact objects.
