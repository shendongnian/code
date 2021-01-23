    using System;
    using System.Threading;
    
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v2;
    using Google.Apis.Services;
    
    class Test
    {
        static void Main(string[] args)
        {
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = /* YOUR CLIENT ID HERE */,
                    ClientSecret = /* YOUR CLIENT SECRET HERE */,
                },
                new[] { DriveService.Scope.Drive },
                /* USER TO AUTHORIZE */,
                CancellationToken.None).Result;
    
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Stack Overflow Drive test",
            });
    
            var response = service.Files.List().Execute();
            foreach (var item in response.Items)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
