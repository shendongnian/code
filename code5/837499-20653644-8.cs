    public static void MakeNull(ref MyClass result)
    {
        result = null;
    }
   
    MyClass c = new MyClass();
    MakeNull(ref c);
    Console.Write(c == null); // true
