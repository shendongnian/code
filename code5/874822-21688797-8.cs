    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }
        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }
        public DateTime BirthDate { get; set; }
        public string InvitationCode { get; set; }
        public int PatientNumber { get; set; }
    }
