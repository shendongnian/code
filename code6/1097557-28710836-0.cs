    public class BESGoogleContactsService
    {
    
        private const string serviceAccountEmail = "123-123123@developer.gserviceaccount.com";
        private const string serviceAccountCertPath = "BesSSO-123.p12";
        private const string serviceAccountCertPassword = "notasecret";
        private const string Email = "225342@domain.com";
    
        public BESGoogleContactsService()
        {
            var certificate = new X509Certificate2(serviceAccountCertPath, serviceAccountCertPassword, X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = new[] { "https://www.google.com/m8/feeds/" },
                    User = Email
                }.FromCertificate(certificate));
    
            bool success = credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None).Result;
    
            RequestSettings settings =
                new RequestSettings("Google Sync.", credential.Token.AccessToken) 
                { 
                    AutoPaging =true,
                    UseSSL = true
                };
    
            ContactsRequest cr = new ContactsRequest(settings);
            
            PrintAllContacts(cr);
        }
    
        public static void PrintAllContacts(ContactsRequest cr)
        {
            Feed<Contact> feed = cr.GetContacts(Email);
    
            Console.WriteLine(feed.TotalResults);
    
            foreach (Contact entry in feed.Entries)
            {
                    Console.WriteLine(entry.Name.FullName);
            }
        }
    }
