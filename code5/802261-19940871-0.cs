        public static Feed<Contact> MakeRequest(string userId, int numberToRetrieve = 9999)
        {
            var serviceCredential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(ServiceEmail)
            {
                Scopes = new[] { @"https://www.google.com/m8/feeds/" },
                User = userId,
            }.FromCertificate(Certificate));
            var reqAccessTokenInfo = serviceCredential.GetType()
              .GetMethod("RequestAccessToken", BindingFlags.Instance | BindingFlags.NonPublic);
            var task = (Task<bool>) reqAccessTokenInfo.Invoke(serviceCredential, parameters: new object[] {new CancellationToken()});
            task.Wait();
            var settings = new RequestSettings(Properties.Settings.Default.ApplicationName, serviceCredential.Token.AccessToken);
            var cRequest = new ContactsRequest(settings);
            var query = new ContactsQuery(ContactsQuery.CreateContactsUri(userId)) { NumberToRetrieve = numberToRetrieve };
            return cRequest.Get<Contact>(query);
        }
