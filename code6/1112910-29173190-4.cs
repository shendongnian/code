    private class LogFileDatabase
    {
        public const string NamePrefix = "dbName:";
        public const string ServerPrefix = "ServerToRestoreTo:";
        public string DbName { get; set; }
        public string Server { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\"{1}\"{2}{3}\"{4}\"",
                NamePrefix, DbName, Environment.NewLine, ServerPrefix, Server);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LogFileDatabase) obj);
        }
        private bool Equals(LogFileDatabase other)
        {
            return (string.Equals(DbName, other.DbName) && 
                string.Equals(Server, other.Server));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((DbName != null ? DbName.GetHashCode() : 0) * 397) ^
                        (Server != null ? Server.GetHashCode() : 0);
            }
        }
    }
