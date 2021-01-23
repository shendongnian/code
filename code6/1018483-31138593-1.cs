    [AllowCrossDomain]
    public string Get(string Email, string Password)
        {
            Request.Headers.Add("Access-Control-Allow-Origin", "*");
            return Email + " : " + Password;
        }
