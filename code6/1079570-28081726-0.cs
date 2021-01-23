    public class ExtentionMethods {
      public static string ToJson(this List<TContract> lst) 
          where TContract : MsgContract
      {
         foreach (var item in lst)
            string entry += item.ToJson();
    
         return entry;
      }
    }
