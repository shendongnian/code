            private void GetListLeads()
        {
            string token = GetToken().Result;
            string listID = "XXXX";  // Get from Marketo UI
            LeadListResponse leadListResponse = GetListItems(token, listID).Result;
            //TODO:  do something with your list of leads
        }
        private async Task<string> GetToken()
        {
            string clientID = "XXXXXX"; // Get from Marketo UI
            string clientSecret = "XXXXXX"; // Get from Marketo UI
            string url = String.Format("https://XXXXXX.mktorest.com/identity/oauth/token?grant_type=client_credentials&client_id={0}&client_secret={1}",clientID, clientSecret ); // Get from Marketo UI
            var fullUri = new Uri(url, UriKind.Absolute);
 
            TokenResponse tokenResponse = new TokenResponse();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(fullUri);
                if (response.IsSuccessStatusCode)
                {
                    tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        throw new AuthenticationException("Invalid username/password combination.");
                    else
                        throw new ApplicationException("Not able to get token"); 
                }
            }
            return tokenResponse.access_token;
        }
        private async Task<LeadListResponse> GetListItems(string token, string listID)
        {
            string url = String.Format("https://XXXXXX.mktorest.com/rest/v1/list/{0}/leads.json?access_token={1}", listID, token);// Get from Marketo UI
            var fullUri = new Uri(url, UriKind.Absolute);
            LeadListResponse leadListResponse = new LeadListResponse();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(fullUri);
                if (response.IsSuccessStatusCode)
                {
                    leadListResponse = await response.Content.ReadAsAsync<LeadListResponse>();
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        throw new AuthenticationException("Invalid username/password combination.");
                    else
                        throw new ApplicationException("Not able to get token");
                }
            }
            return leadListResponse;
        }
        private class TokenResponse
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
        }
        private class LeadListResponse
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public string nextPageToken { get; set; }
            public Lead[] result { get; set; }
        }
        private class Lead
        {
            public int id { get; set; }
            public DateTime updatedAt { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public DateTime datecreatedAt { get; set; }
            public string firstName { get; set; }
        }
