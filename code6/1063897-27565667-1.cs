     public static class ListExtensions
        {
            public static Void ExtensionMethodName<T>(this List<T> list) where T : MyClass
            {
                //Code
            }
            // Or
            public static Void ExtensionMethodName(this List<MyClass> list)
            {
                //Code
            }
        }
