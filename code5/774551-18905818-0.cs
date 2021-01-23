    public static class ObjectExtension
    {
        public static bool IsNot<T>(this object o)
        {
            return !(o is T);
        }
    }
    //Use it
    if(myObj.IsNot<MyClass>()){
      //...
    }
