        public static class MethodInfo
        {
            public static System.Reflection.MethodInfo From(Func<string, int> func)
            {
                return func.Method;
            }
            // Other members for Action<T>, Action<T1, T2> etc.
            // Other members for Func<T>, Func<T1, T2> etc.
        }
