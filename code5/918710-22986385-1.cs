    public class BCFactory {
      public SubClass CreateInstance(string key)
      {
         var val1 = GetVal1FromKey(key);
         var val2 = GetVal2FromKey(key);
         // create the actual instance of the subclass
         var instance = new SubClass(val1, val2);
         return instance;
      }
    }
    public class SubClass {
       public SubClass(string val1, string val2) : base(val1, val2)
       {
          // Do nothing, we just instantiate the base class.
       }
    }
