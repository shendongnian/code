    public class ParentClass
    {
       protected List<string> keys = new List<String>();
    
        public ParentClass 
        {
            keys.Add("Parent")
        }
    
       public void GenerateKey()
       {
           Console.WriteLine(keys.Join("_"));
       }
    }
    
    public class FeatureClass : ParentClass
    {
       keys.Add("Feature");
    
    }
    
    public class SubFeatureClass : FeatureClass 
    {
    keys.Add("SubFeature");
    
    }
