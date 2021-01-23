    public static U PostLogin<U>(string url, Authentication obj)
                where U : new()
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri(host + url);
                var request = new RestRequest(Method.POST);
                string encodedBody = string.Format("grant_type=password&username={0}&password={1}",
                    obj.username,obj.password);
                request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
                request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
                var response = client.Execute<U>(request);
                
                 return response.Data;
    
            }
