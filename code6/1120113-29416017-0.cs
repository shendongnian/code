     var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets() { 
                        ClientId = "yourclientid", 
                        ClientSecret = "yourclientsecret" },
                    new string[] { ShoppingContentService.Scope.Content },
                    "user",
                    CancellationToken.None).Result;
      //make this a global variable
      var service = new ShoppingContentService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "Your-app-name"
            });
