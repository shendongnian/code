    public JToken GetLoginResponse(UserSignupDto dto)
    {
        var tokenPath = Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/token";
        var reqData = string.Format("grant_type=password&username={0}&password={1}&client_id={2}", dto.Email, dto.Password, dto.ClientId);
        using(var client = new WebClient())
        {
            return JObject.Parse(client.UploadString(tokenPath, reqData));
        }
    }
