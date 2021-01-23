    [OperationContract, WebGet(UriTemplate = "getAllProduct/{value}")]
    public System.ServiceModel.Channels.Message GetAllProduct(string value)
    {
        Dictionary<int, Product> dict = .......
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
        return WebOperationContext.Current.CreateTextResponse(
            JsonConvert.SerializeObject(dict)
        );
    }
