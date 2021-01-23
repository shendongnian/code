    public class MyClass<TypeAsParam>
          {
             public OnGo<TypeAsParam> MyDelegate;
    
             public void Msg(TypeAsParam msg)
             {
                MyDelegate(msg); 
             }
          }
