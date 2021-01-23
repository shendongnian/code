    public static void MakeNull(MyClass result)
    {
        result = null;
    }
   
    MyClass c = new MyClass();
    MakeNull(c);
    Console.Write(c == null); // false
