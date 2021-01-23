    public class ParentClass
    {
        private string key;
        protected ParentClass(params string[] keys)
        {
            key = "Parent";
            if (keys.Length > 0)
                key += "_" + string.Join("_", keys);
        }
        public void GenerateKey()
        {
            // Get keys from subclasses
            Console.WriteLine(key);
        }
    }
    public class FeatureClass : ParentClass
    {
        public FeatureClass() : base("Feature") { }
        protected FeatureClass(string key) : base("Feature", key) { }
    }
    public class SubFeatureClass : FeatureClass 
    {
        public SubFeatureClass() : base("SubFeature") { }
    }
