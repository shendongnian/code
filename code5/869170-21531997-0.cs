    public abstract class ParentClass
    {
       private string key = "Parent";
       protected abstract string derivedKey
       {
            get;
       }
       public void GenerateKey()
       {
           Console.WriteLine(key + derivedKey);
       }
    }
    public class FeatureClass : ParentClass
    {
       public string derivedKey
       {
            get
            {
                 return "Feature";
            }
        }
    }
