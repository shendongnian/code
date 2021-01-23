    public class KeyStore
    {
        public Dictionary<string, string> PrimaryKeys { get; set; }
        
        public KeyStore(string pkName, string pkValue)
        {
            PrimaryKeys = new Dictionary<string, string> { { pkName, pkValue } };
        }
        public KeyStore()
        {
            PrimaryKeys = new Dictionary<string, string>();
        }
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
                return false;
            // If parameter cannot be cast to KeyStore return false.
            KeyStore targetKeyStore = obj as KeyStore;
            if (targetKeyStore == null)
                return false;
            return PrimaryKeys.OrderBy(pk => pk.Key).SequenceEqual(targetKeyStore.PrimaryKeys.OrderBy(pk => pk.Key));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ PrimaryKeys.GetHashCode();
        }
    }
