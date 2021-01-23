    class LoginResponseDetails
    {
        public string SessionId {get;set;} // this might be better as a GUID
        // either this
        public List<Tuple<Guid, string>> Businesses {get;set;} // untested and not 100% sure on this
        // or this
        public Hashtable Businesses {get;set;}
        // other properties here...
    }
    class LoginResponse
    {
        LoginResponseDetails Response {get;set;}
        // other properties here...
    }
