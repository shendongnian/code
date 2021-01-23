    public class UserContext
    {
        private Auth m_auth;
        public string AccountNo { get; set; }
        public string AuthValue { get; set; }
        public Auth AuthObject
        {
            get
            {
                if (this.m_auth == null)
                {
                    this.m_auth = JsonConvert.DeserializeObject<Auth>(this.AuthValue);
                }
                return this.m_auth;
            }
        }
    }
