        public System.IO.Stream GetResults()
        {
           string str=//Call RestServiceB which returns response as below.
           "query":"myquery", "results": [ {"name":"result1", "type":"suggest"}, {"name":"result2", "type":"type2"}]"         
            WebOperationContext.Current.OutgoingResponse.ContentType =
            "application/json; charset=utf-8";
            return new MemoryStream(Encoding.UTF8.GetBytes(str));
        }
        [OperationContract ]
        [WebGet(UriTemplate = "getresults")]
        String GetResults();
