    public class ParentClass
    {
       public ParentClass(){Key = "Parent";}
       private virtual string Key {get;set;}
    
       public void GenerateKey()
       {
           Console.WriteLine(Key);
       }
    }
    
    public class FeatureClass : ParentClass
    {
        public FeatureClass(){Key = base.Key + "_" + "Feature";}
        override string Key {get;set;}
    }
