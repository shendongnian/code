    public class User
    {
        public string User  { get; set; }
        public string ClientToken { get; set; }
        public string AccessToken { get; set; }
        public string UserUUID { get; set; }
        public string PassLength { get; set; }
        public override string ToString()
        {
            return string.Format("user :{0}, clientToken: {1}, AccessToken: {2},UserUUID :{3},  PassLength:{4}", User, ClientToken, AccessToken, UserUUID, PassLength);
        }
    }
