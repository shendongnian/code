    public sealed class LoggingConfiguration : ConfigurationSection
    {
        private const string ConnectionStringKey = "connectionString";
        [ConfigurationProperty(ConnectionStringKey, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string) base[ConnectionStringKey]; }
            set { base[ConnectionStringKey] = value; }
        }        
    }
