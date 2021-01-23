    class ConfigurationComparer : IEqualityComparer<Configuration>
    {
        //You can change which string comparer fits your needs best.
        private readonly StringComparer comparer = StringComparer.CurrentCulture;
        public bool Equals(Configuration x, Configuration y)
        {
            return comparer.Equals(x.DocKey,y.DocKey);
        }
    
        public int GetHashCode(Configuration obj)
        {
             return comparer.GetHashCode(obj.DocKey);
        }
    
    }
