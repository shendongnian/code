    public static UserProfile UserLogin(UserLogin userLogin)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("api/UserLoginApi/", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(userLogin);
    
            var response = client.Execute(request);
    
            var userProfile = JsonConvert.DeserializeObjectAsync<UserProfile>(response.Content).Result;
    
            return userProfile;
        }  
    
    
      
