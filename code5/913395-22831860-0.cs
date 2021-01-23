    static private void TestBoxingAndUnboxing()
    {
     int i = 123;
     object o = i; // Implicit boxing
     i = 456; // Change the contents of i
     int j = (int)o; // Unboxing (may throw an exception if the types are incompatible)
    }
    //this function is about 2*Log(N) faster
    static private void TestNoBoxingAndUnboxing()
    {
     int i = 123;
     i = 456; // Change the contents of i
     int j = i; // Compatible types
    }
