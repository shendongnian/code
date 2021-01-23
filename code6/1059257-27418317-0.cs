    RestClient _authClient = new RestClient("https://sample.com/account/login");
    RestRequest _credentials = new RestRequest(Method.POST);
    _credentials.AddCookie(_cookie[0].Name, _cookie[0].Value);
    _credentials.AddParameter("userLogin", _username, ParameterType.GetOrPost);
    _credentials.AddParameter("userPassword", _password, ParameterType.GetOrPost);
    _credentials.AddParameter("submit", "", ParameterType.GetOrPost);
    RestResponse _credentialResponse = (RestResponse)_authClient.Execute(_credentials);
    Console.WriteLine("Authentication phase Uri   : " + _credentialResponse.ResponseUri);
