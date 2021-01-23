    public static void SomeTestMethod(int number,string str)
    {
        Check( () => MethodOne(number,str));
    }
    
    public static int Check(Func<int> method)
    {
             // some conditions 
          return method();
    }
