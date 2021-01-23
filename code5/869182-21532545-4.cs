    public class ParentClass
    {
        private string key;
        protected ParentClass(string childKeys)
        {
            key = !string.IsNullOrEmpty(childKeys) ? key + "Parent_" + childKeys : key;
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
        protected FeatureClass(string key) : base("Feature_" + key) { }
    }
    public class SubFeatureClass : FeatureClass 
    {
        public SubFeatureClass() : base("SubFeature") { }
        protected SubFeatureClass(string key) : base("SubFeature_" + key) { }
    }
    public class ReallySubFeatureClass : SubFeatureClass
    {
        public ReallySubFeatureClass() : base("ReallySubFeature") { }
    }
