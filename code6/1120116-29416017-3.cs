     var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets() { 
                        ClientId = "yourclientid", 
                        ClientSecret = "yourclientsecret" },
                    new string[] { ShoppingContentService.Scope.Content },
                    "user",
                    CancellationToken.None).Result;
      //make this a global variable or just make sure you pass it to InsertProductBatch or any function that needs to use it
      service = new ShoppingContentService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "Your-app-name"
            });
