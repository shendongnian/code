    partial class MyClass
    {
    #if FOR_FLOAT
        using Double = System.Single;
    #endif
        public void Update(Double[] arr, int startIndex, int endIndex)
        {
            // do whatever you want, using Double where you want the type to change, and
            // either System.Double or double where you don't
        }
    }
