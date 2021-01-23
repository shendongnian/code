        /// <summary>
        /// Test method that returns pings the service
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "ping", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string Ping();
