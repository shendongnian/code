    class AnyObjectAsITest : ITest {
     public object Object;
     public string PropertyName;
    
     public int ID {
      get {
       return (int)Object.GetType().GetProperty(PropertyName).GetValue(Object, null);
      }
     }
     //...
    }
