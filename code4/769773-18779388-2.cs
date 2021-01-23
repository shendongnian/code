    public void AddAccount(string accountname, Action<bool> success, Action<bool> failure)
        { var client = new RestClient("http://[localhost]/CustomerPortalService12");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("AddAccount/AccountsReceivable/" + accountname, Method.GET);
            client.ExecuteAsync(request, (response) =>
            {
                if (response.ResponseStatus == ResponseStatus.Error)
                {
                    failure(response.ErrorMessage);
                }
                else
                {
                    var result= JsonConvert.DeserializeObject<bool>(response.Content);
                    success(result);
                }
            }); }
