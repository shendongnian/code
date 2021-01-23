     public static class ListExtensions
        {
            public static void ExtensionMethodName<T>(this List<T> list) where T : MyClass
            {
                //Code
            }
            // Or
            public static void ExtensionMethodName(this List<MyClass> list)
            {
                //Code
            }
        }
