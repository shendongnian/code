     public delegate void OnGo<TypeInDel>(TypeInDel obj);
    
            public class MyClass<TypeAsParam> where TypeAsParam : new()
            {
                public OnGo<TypeAsParam> MyDelegate;
    
                public void Msg()
                {
                    TypeAsParam msg =  new TypeAsParam();
                    MyDelegate(msg); 
                }
            }
