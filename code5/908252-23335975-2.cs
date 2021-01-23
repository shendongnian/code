        public SignalRUser()
        {
            this.SignalRConnections = new HashSet<SignalRConnection>();
        }
        public string UserName { get; set; }
        public virtual ICollection<SignalRConnection> SignalRConnections { get; set; }
    }
