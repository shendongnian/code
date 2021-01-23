      private bool DoesSomethingExist(string something, string queueOrExchange)
        {
            var connectionInfo = GetRabbitConnectionInfo();
            var url = string.Format("{0}/{1}/{2}/{3}", connectionInfo.APIUrl, queueOrExchange, connectionInfo.VirtualHostName, something);
            using (var client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", connectionInfo.UserName, connectionInfo.Password));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
    
                var content = response.Content;
                throw new Exception(string.Format("Unhandled API response code of {0}, content: {1}", response.StatusCode, content));
            }
        }
