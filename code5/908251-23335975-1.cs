        public string ConnectionID { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }
        public string SignalRUser_UserName { get; set; }
        public virtual SignalRUser SignalRUser { get; set; }
    }
