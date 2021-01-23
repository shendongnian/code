        [ServiceContract]
        interface IConnectionService
        {
            [WebGet(UriTemplate = "GetState", BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json), Description("")]
            State GetState();
        }
