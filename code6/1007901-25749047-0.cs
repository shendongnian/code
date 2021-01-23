    namespace System.Collection.Generic {
       public static class SystemEx {
            public static bool IsEmpty<T>(this Stack<T> stack) {
                return (stack.Count==0);
            }    
       }
