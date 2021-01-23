            /*{
              "agent": {                             
                "name": "Agent Name",                
                "version": 1                                                          
              },
              "username": "Username",                                   
              "password": "User Password",
              "token": "xxxxxx"
            }*/
            JObject payLoad = new JObject(
                new JProperty("agent", 
                    new JObject(
                        new JProperty("name", "Agent Name"),
                        new JProperty("version", 1)
                        ),
                    new JProperty("username", "Username"),
                    new JProperty("password", "User Password"),
                    new JProperty("token", "xxxxxx")    
                    )
                );
            using (HttpClient client = new HttpClient())
            {
                var httpContent = new StringContent(payLoad.ToString(), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync(requestUri, httpContent))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(responseBody);
                }
            }
