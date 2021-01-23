    public String Post(ClassName obj)
    {
        String url = string.Format("{0}{1}", "DomainName comes here",
                        "Controller Name/Action Method Name");
        var httpClient = new HttpClient();
        var responseMessage = httpClient.PostAsync(url, 
                new ObjectContent<ClassName>(obj, new JsonMediaTypeFormatter())).Result;
        return responseMessage.ReasonPhrase;
    }
