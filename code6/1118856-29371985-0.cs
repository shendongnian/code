    public class UserState
    {
        public string UserName { get; set; }
        public bool CheckedIn { get; set; }
        public override string ToString() { return String.Format("{0}={1}", UserName, CheckedIn); }
    }
