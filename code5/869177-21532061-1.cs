    public class ParentClass
    {
        protected List<string> keys = new List<string>();
    
        public ParentClass()
        {
            keys.Add("Parent");
        }
    
        public void GenerateKey()
        {
            Console.WriteLine(string.Join("_", keys));
        }
    }
    
    public class FeatureClass : ParentClass
    {
        public FeatureClass()
        {
            keys.Add("Feature");
        }
    }
    
    public class SubFeatureClass : FeatureClass
    {
        public SubFeatureClass()
        {
            keys.Add("SubFeature");
        }
    
    }
