    public class ExtentionMethods {
      public static string ToJson<TContract>(this List<TContract> lst) 
          where TContract : MsgContract
      {
         foreach (var item in lst)
            string entry += item.ToJson();
    
         return entry;
      }
    }
