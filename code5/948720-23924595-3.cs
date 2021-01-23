      public class Foo<T>
      {
          public T Data
          {
              get;
              protected set;
          }
        
                public Foo()
                {
                    switch (Type.GetTypeCode(Data.GetType()))
                    {
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                            Data = (T)Convert.ChangeType(42, typeof(T));
                            break;
                        default:
                            break;
                    }
        
                }
        
            }
