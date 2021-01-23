    public class BCFactory {
      public BaseClass CreateInstance(string key)
      {
         var val1 = GetVal1FromKey(key);
         var val2 = GetVal2FromKey(key);
         // create the actual instance
         var instance = new BaseClass(val1, val2);
         return instance;
      }
    }
