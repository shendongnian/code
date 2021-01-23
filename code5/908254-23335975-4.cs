     public partial class SignalRConnection
        {
            public string ConnectionID { get; set; }
            public string UserAgent { get; set; }
            public bool Connected { get; set; }
            public string SignalRUser_UserName { get; set; }
    
            public virtual SignalRUser SignalRUser { get; set; }
        }
    public partial class SignalRUser
        {
        public SignalRUser()
        {
            this.SignalRConnections = new HashSet<SignalRConnection>();
        }
        public string UserName { get; set; }
        public virtual ICollection<SignalRConnection> SignalRConnections { get; set; }
    }
    }
