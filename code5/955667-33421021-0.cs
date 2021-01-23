        [OperationContract, WebGet(UriTemplate="ProcessSomething?a={a}&b={b}")]
        public void GetData(string a, string b)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://www.microsoft.com");
         
            //process request here
        }
    }
