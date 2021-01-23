    [DataContract]
    public class Connection
    {
        [DataMember]
        public string UserName { get; set; }
    
        public Connection(string userName)
        {
            UserName = userName;
        }
        public static Connection Default { get; set; }
        static Connection()
        {
            Default = new Connection("username");
        }
        
    }
