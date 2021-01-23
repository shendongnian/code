            const string ServiceAccountUser = "xxxxxxxxxx@developer.gserviceaccount.com";
            AssertionFlowClient client = new AssertionFlowClient(
                GoogleAuthenticationServer.Description, new X509Certificate2(@"C:\xxxxxxxxxxx-privatekey.p12", "notasecret", X509KeyStorageFlags.Exportable))
            {
                Scope = AnalyticsService.Scopes.AnalyticsReadonly.GetStringValue(),
                ServiceAccountId = ServiceAccountUser //Bug, why does ServiceAccountUser have to be assigned to ServiceAccountId
                //,ServiceAccountUser = ServiceAccountUser
            };
            //OAuth2Authenticator<AssertionFlowClient> authenticator = new OAuth2Authenticator<AssertionFlowClient>(client, AssertionFlowClient.GetState);
            var authenticator = new OAuth2Authenticator<AssertionFlowClient>(client, AssertionFlowClient.GetState);
            var service = new AnalyticsService(new BaseClientService.Initializer()
            {
                Authenticator = authenticator
            });
            string profileId = "ga:63494033";
            string startDate = "2010-10-01";
            string endDate = "2010-10-31";
            string metrics = "ga:visits";
            DataResource.GaResource.GetRequest request = service.Data.Ga.Get(profileId, startDate, endDate, metrics);
            request.Dimensions = "ga:date";
            GaData data = request.Execute();   
        }
