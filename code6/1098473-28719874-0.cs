    public void Read(string urlParameters, string path)
    {
        string _clientURL = _url + urlParameters;
        _client = new RestClient(_clientURL);
        var req = new RestRequest(Method.GET);
        req.AddParameter("Content-Type", "text/csv", ParameterType.HttpHeader);
        req.AddParameter("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_apikey+':'+_passWord)), ParameterType.HttpHeader);
        var response = _client.Execute(req);
        File.WriteAllText(path, response);
    }
