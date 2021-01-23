    public class CountEnum
    {
       public static readonly CountEnum DEFAULT = new CountEnum();
       private static readonly List<CountEnum> AllInstances = new List<CountEnum>();
    
       private CountEnum()
       {
           AllInstances.Add(this);
       }
    }
