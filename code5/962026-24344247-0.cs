    public class LoginResponse : BasicResponse
    {
        public LoginResponse(string[] responseData) : base(responseData) { }
        public override void DoSomeStuffWithTheResponse()
        { 
        }
    
        public override BasicResponse DoRequest(string[] requestData) 
        {
            // Do stuff
            return new LoginResponse();
        }
    }
