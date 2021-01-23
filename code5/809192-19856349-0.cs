    class LoginResponseDetails
    {
        public string SessionId {get;set;} // this might be better as a GUID
        // other properties here...
    }
    class LoginResponse
    {
        LoginResponseDetails Response {get;set;}
        // other properties here...
    }
