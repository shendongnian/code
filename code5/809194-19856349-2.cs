    class LoginResponseDetails
    {
        public string SessionId {get;set;} // this might be better as a GUID
        public Hashtable Businesses {get;set;} // this could be Dictionary<string, string> or Dictionary<Guid, string>
        // other properties here...
    }
    class LoginResponse
    {
        LoginResponseDetails Response {get;set;}
        // other properties here...
    }
