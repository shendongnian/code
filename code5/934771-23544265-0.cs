    private async void GetToken(ClaimsPrincipal claimsPrincipal)
            {
                string upn = claimsPrincipal.FindFirst(
                     "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;
                string tenantID = claimsPrincipal.FindFirst(
          "http://schemas.microsoft.com/identity/claims/tenantid").Value;
                 string requestUrl = string.Format("https://graph.windows.net/{0}/users/{1}/memberOf?api-version=2013-04-05",
                tenantID, upn);
                
                string appPrincipalID = "152313bf-2566-4bbb-8160-06013dc45679";//This is the cliend id you get after creating web api on azure 
                string appKey = "XP7rvrbzOXl6n94STPgI6LTqU1fOTje4cu+Cererererer8nE=";//generate it on web app on azure 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(
                          "https://login.windows.net/{0}/oauth2/token?api-version=1.0",
                          domainName));
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                string postData = "grant_type=client_credentials";
                postData += "&resource=" + HttpUtility.UrlEncode("https://graph.windows.net");
                postData += "&client_id=" + HttpUtility.UrlEncode(appPrincipalID);
                postData += "&client_secret=" + HttpUtility.UrlEncode(appKey);
                byte[] data = encoding.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                //string authorizationHeader = string.Empty;
                Models.AADJWTToken token = null;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                    using (var response = request.GetResponse())
                    {
                        using (var stream1 = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream1))
                            {
                                string str = await reader.ReadToEndAsync();
                                token = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.AADJWTToken>(str);                              
                            }
                        }
                    }
                }
               HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
               var re = await httpClient.GetAsync(requestUrl);
                var se = await re.Content.ReadAsStringAsync();
             //this variable hold your result with user group in json format.
               
            }
