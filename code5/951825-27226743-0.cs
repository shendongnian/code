    public void Login()
        {
            object loginData = new
            {
                user_auth = new
                {
                    user_name = Username,
                    password = CalculateMD5Hash(Password)
                }
            };
            string jsonData = CreateFormattedPostRequest("login", loginData);
            var request = GetRestRequest(jsonData, "POST");
            var loginResponse = GetRestResponseByType<LoginResponse>(request);
            if (string.IsNullOrEmpty(loginResponse.id))
            {
                throw new SugarException(string.Concat("Authorisation Failed for user: {0}, did not retrieve access token", Username));
            }
            SessionID = loginResponse.id;
        }
