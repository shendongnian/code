     private async void VerifyUser()
             {
                loginParams = "username=" + logInUserIdString + "&password=" + logInPasswordString;
                string teamResponse = "https:// mySite.com?" + loginParams;
                Debug.WriteLine(teamResponse);
    
                HttpClient client = new HttpClient();
    
                try
                {
                    HttpResponseMessage response = await client.PostAsync(new Uri(teamResponse), null);
    
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
    
                    Debug.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine("\nException Caught!");
                    Debug.WriteLine("Message :{0} ", e.Message);
                }
