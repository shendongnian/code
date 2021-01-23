            string ApiToken = "user token goes here";
            string url = "https://www.toggl.com/api/v8/me"; 
            string userpass = ApiToken + ":api_token";
            string userpassB64 = Convert.ToBase64String(Encoding.Default.GetBytes(userpass.Trim()));
            string authHeader = "Basic " + userpassB64;
            
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(url);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "GET";
            authRequest.ContentType = "application/json";
            //authRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
            
            try
            {
                var response = (HttpWebResponse)authRequest.GetResponse();
                string result = null;
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    result = sr.ReadToEnd();
                    sr.Close();
                }
                if (null != result)
                {
                    System.Diagnostics.Debug.WriteLine(result.ToString());
                }
                // Get the headers
                object headers = response.Headers;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\n" + e.ToString());
            }
