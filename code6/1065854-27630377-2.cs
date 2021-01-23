     public static UserProfile UserLogin(UserLogin userLogin)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("api/UserLoginApi/", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddQueryParameter("EmailAddress", userLogin.EmailAddress);
            request.AddQueryParameter("Password", userLogin.Password);    
            var response = client.Execute(request);    
            var userProfile = JsonConvert.DeserializeObjectAsync<UserProfile>response.Content).Result;    
            return userProfile;
        }
