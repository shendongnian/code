    public void GetTwitterDetail(string _userScreenName)
        {
            var credentials = new OAuthCredentials
              {
                  Type = OAuthType.ProtectedResource,
                  SignatureMethod = OAuthSignatureMethod.HmacSha1,
                  ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                  ConsumerKey = AppSettings.consumerKey,
                  ConsumerSecret = AppSettings.consumerKeySecret,
                  Token = this.accessToken,
                  TokenSecret = this.accessTokenSecret,
              };
            var restClient = new RestClient
            {
                Authority = "https://api.twitter.com/1.1",
                HasElevatedPermissions = true
            };
            var restRequest = new RestRequest
            {
                Credentials = credentials,
                Path = string.Format("/users/show.json?screen_name={0}&include_entities=true", _userScreenName),
                Method = WebMethod.Get
            };
            restClient.BeginRequest(restRequest, new RestCallback(test));
        }
        private void test(RestRequest request, RestResponse response, object obj)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                Console.WriteLine("Content==> " + response.Content.ToString());
                Console.WriteLine("StatusCode==> " + response.StatusCode);
            });
        }
