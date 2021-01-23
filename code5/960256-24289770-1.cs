    var session = JsonConvert.DeserializeObject<Session>(json);
----
    public class Session
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<string> Authorizations { get; set; }
        public string PrimaryAuthorization { get; set; }
        public string ThirdPartyOrgName { get; set; }
        public string Username { get; set; }
        public string SelfUri { get; set; }
    }
