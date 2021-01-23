    static void DummyDynamicTest<T>(this T t) //extension method
    {
    }
    dynamic test = 1;
    try
    {
        test.DummyDynamicTest();
        //not dynamic
    }
    catch (RuntimeBinderException)
    {
        //dynamic
    }
