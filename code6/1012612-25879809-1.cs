    void PrintTypeName(Type t) { Console.WriteLine(t.Name); }
    void PrintTypeName<T>() { Console.WriteLine(typeof(T).Name); }
    void Main()
    {
        Type cType = typeof(C);
        Type dType = typeof(D);
        C cInstance = new C();
        D dInstance = new D();
        PrintNameOfType(cType.GetType());     //prints "RuntimeType"
        PrintNameOfType(dType.GetType());     //prints "RuntimeType"
        PrintNameOfType(cInstance.GetType()); //prints "C"
        PrintNameOfType(dInstance.GetType()); //prints "D"
        PrintNameOfType(cType);     //prints "C"
        PrintNameOfType(dType);     //prints "D"
        //does not compile:
        //PrintNameOfType(cInstance);
        //PrintNameOfType(dInstance);
        PrintNameOfType<Type>(); //prints "Type"
        PrintNameOfType<C>();    //prints "C"
        PrintNameOfType<D>();    //prints "D"
    }
