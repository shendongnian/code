    public static MessageHeader<SecurityHeaderType> GetSecurityHeader(string userName, string passWord, string nonce)
        {
            if (string.IsNullOrEmpty(userName))
            {
                userName = string.Empty;
            }
            if (string.IsNullOrEmpty(passWord))
            {
                passWord = string.Empty;
            }
            if (string.IsNullOrEmpty(nonce))
            {
                nonce = string.Empty;
            }
            var usernameToken = new UsernameToken();
            var securityHeader = new SecurityHeaderType { UsernameToken = usernameToken };
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            string now = DateTime.Now.ToString();
            var tokenManager = new AvivaUsernameTokenManager();
            var passwordDigest = tokenManager.CreatePasswordDigest(Convert.FromBase64String(nonce), now, passWord);
            securityHeader.UsernameToken.Created = now;
            securityHeader.UsernameToken.Nonce = nonce;
            securityHeader.UsernameToken.Password = passwordDigest;
            securityHeader.UsernameToken.Username = userName;
            var header = new MessageHeader<SecurityHeaderType> { Content = securityHeader, Actor = "" };
            return header;
        }
        Public void CallService(){
     const string userName = "username";
            const string passWord = "password";
            const string nonce = "nonce";
            var securityHeader = SecurityHeaderHelper.GetSecurityHeader(userName, passWord, nonce);
            using (new OperationContextScope(_client.InnerChannel))
            {
                var untypedSecurityHeader = securityHeader.GetUntypedHeader("Security", Constants.SecurityHeaderWSSE);
                OperationContext.Current.OutgoingMessageHeaders.Add(untypedSecurityHeader);
               var dummyRequest = new DummyRequest();
                try
                {
                    var testResponse = _client.Call(dummyRequest);
                }
                catch (Exception exp)
                {
                    Assert.Fail(exp.Message);
                }               
            }
        }}
