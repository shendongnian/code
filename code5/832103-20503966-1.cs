    public static List<Difference<T>> Detailed Difference<T>(this T val1, T val2,
                                                             T newValue)
        where T : new()
    // call like
    var diff = myClass1.Difference(myClass2, new MyClass(someParam));
