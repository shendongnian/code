    namespace MyNamespace // <- Just a namespace
    {
        // Anonymous Namespace emulation:
        //   static class can't have instances and can't be inherited, 
        //   it's abstract and sealed
        internal static class InternalClass // or public static class
        {
            // private class, it's visible within InternalClass only  
            class my_private_class 
            { ... }
        }
    }
