    public delegate void OnGo<TypeInDel>(TypeInDel obj);
    public class MyClass<TypeAsParam>
    {
        public OnGo<TypeAsParam> MyDelegate;
        public void Msg()
        {
          TypeAsParam msg = default(TypeAsParam);
          MyDelegate(msg); //here is wrong in VS editor, says cannot cast msg to TypeAsParam(not TypeInDel)
        }
    }
  
