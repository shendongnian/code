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
       public override string derivedKey
       {
            get
            {
                 return "Feature";
            }
        }
    }
