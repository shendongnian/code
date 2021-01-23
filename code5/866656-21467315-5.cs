    class MyClass<T>
    {
        public static MyClass<T> operator +(MyClass<T> c1, MyClass<int> c2)
        {
            return new MyClass<T>();
        }
 
    }
    //...
    
    // Add MyClass<string> to MyClass<int>. 
    // As you can see we have appropriate version of operator overloading for doing this without exceptions.
    var c1 = new MyClass<string>();
    var c2 = new MyClass<int>();
    var res = Add(c1, c2);
