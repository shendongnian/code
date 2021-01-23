    // creates a Podio.API.Client used to communicate with the Podio API
    var client = Podio.API.Client.ConnectAsUser(client_id, client_secret, username, password);
    
    // Get a single item
    int itemId = 123;
    var item = client.ItemService.GetItem(itemId);
    
    // Get many items from an app
    int appId = 123;
    int limit = 100 // Max allowed is 500 items per request;
    int offset = 0;
    var items = client.ItemService.GetItems(appId, limit, offset);
